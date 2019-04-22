using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Jugador : NetworkBehaviour
{
    #region Variables
    /*
     * VARIABLES DE CONTROL DE CÁMARA.
     */

    // Este valor controlará la sensibilidad del ratón.
    public float sensibilidadRaton;

    //Este valor evitará que la cámara pueda girar 360º.
    private float restriccionEjeX;

    //Obtenemos el GameObject que es el cuerpo del jugador.
    public GameObject cuerpo;

    //Cámara posicionada en primera persona.
    [SerializeField] Camera camara;

    /**
     * VARIABLES DE CONTROL DE JUGADOR.
     */
    
    // Este valor controlará la velocidad de movimiento del jugador.
    [SerializeField] private float velocidad = 5;

    // Valor que controla la fuerza de impacto.
    [SerializeField] private float knockbackValue = 7;

    // Este es control del jugador.
    private CharacterController controlJugador;

    private FuerzaImpacto fz;

    #endregion

    #region Metodos Unity
    /// <summary>
    /// Se ejecuta antes de que el GameObject del jugador
    /// sea creado.
    /// </summary>
    void Awake()
    {
        BloquearRaton();
        controlJugador = GetComponent<CharacterController>();
        fz = GetComponent<FuerzaImpacto>();
    }

    // Se ejecuta en el primer frame del juego.
    void Start()
    {
        if (isLocalPlayer)
        {
            camara.gameObject.SetActive(true);
        } else
        {
            camara.gameObject.SetActive(false);
        }
    }

    // Se ejecuta en cada fotograma del juego.
    void Update()
    {
        
        if (!isLocalPlayer)
        { 
            return;
        }

        if (!GlobalVars.IsInPauseMenu)
        {
            RotacionCamara();
            MovimientoJugador();
        }
    }

    /// <summary>
    /// Evento que se ejecuta cuando se destruye
    /// este GameObject.
    /// </summary>
    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            print("Hit!");
            NetworkServer.Destroy(other.gameObject);
            AplicarFuerzaImpacto();
        }
    }    
    #endregion

    #region Metodos Propios
    /// <summary>
    /// Bloquea el ratón dentro del juego mientras que
    /// el jugador esté siendo controlado.
    /// </summary>
    void BloquearRaton()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Usando los ejes de entrada del ratón, controla la cámara desde
    /// una perspectiva en primera persona.
    /// </summary>
    void RotacionCamara()
    {
        //Se obtienen los ejes de entrada del ratón, multiplicados por la sensibilidad de ratón.
        float ratonX = Input.GetAxis("Mouse X") * sensibilidadRaton * Time.deltaTime;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidadRaton * Time.deltaTime;

        /*
         * Esta sección de código nos permite que, si la suma de la rotación
         * del eje Y del ratón es mayor que 90º, ó menor que -90º, que la cámara
         * no siga moviendose más.
         */
        restriccionEjeX += ratonY;

        if (restriccionEjeX > 90.0f)
        {
            restriccionEjeX = 90.0f;
            ratonY = 0.0f;
            RestringirRotacionEjeXAValor(270.0f);
        }
        else if (restriccionEjeX < -90.0f)
        {
            restriccionEjeX = -90.0f;
            ratonY = 0.0f;
            RestringirRotacionEjeXAValor(90.0f);
        }

        /* 
         * Para obtener movimiento en vertical, multiplicamos el Vector3 del eje X de la cámara (eje X en 3D)
         * por el valor ratonY (eje Y en 2D) en el momento en el que el método es llamado. (En este caso, un 
         * Vector3(-1, 0, 0)*valor eje Y del ratón).
         */
        camara.transform.Rotate(Vector3.left * ratonY);
        /*
         * Para obtener el movimiento en horizontal, multiplicamos el Vector3 del eje Y del CUERPO del jugador
         * (aquí lo hacemos del cuerpo del jugador pues ya que cuando giramos la cabeza en la vida real, llegados
         * a un punto, nosotros físicamente acabamos rotando también) (Eje Y en 3D) por el valor ratonX (Eje X en
         * 2D) en el momento en el que el método es llamado. (En este caso, un Vector3(0, 1, 0)*valor eje X del ratón).
         */
        cuerpo.transform.Rotate(Vector3.up * ratonX);
    }

    /// <summary>
    /// Aplica sobre el eje X en los ángulos Euler actuales
    /// el valor especificado.
    /// </summary>
    /// <param name="valor">Valor a aplicar sobre X.</param>
    void RestringirRotacionEjeXAValor(float valor)
    {
        Vector3 rotacionEuler = transform.eulerAngles;
        rotacionEuler.x = valor;
        camara.transform.eulerAngles = rotacionEuler;
    }

    /// <summary>
    /// Utilizando los ejes verticales y horizontales de entrada de teclado,
    /// mueve al jugador.
    /// </summary>
    void MovimientoJugador()
    {
        float entradaVertical = Input.GetAxis("Vertical") * velocidad;
        float entradaHorizontal = Input.GetAxis("Horizontal") * velocidad;

        Vector3 movimientoHaciaDelante = transform.forward * entradaVertical;
        Vector3 movimientoADerecha = transform.right * entradaHorizontal;

        controlJugador.SimpleMove(movimientoHaciaDelante + movimientoADerecha);
    }

    /// <summary>
    /// Aplica un empuje hacia atrás al jugador.
    /// </summary>
    void AplicarFuerzaImpacto()
    {
        fz.AddImpact(-transform.forward, knockbackValue);
    }

    public void Lanzar(Vector3 direccion, float fuerza)
    {
        fz.AddImpact(direccion, fuerza);
    }

    #endregion
}
