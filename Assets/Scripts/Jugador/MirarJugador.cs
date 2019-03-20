using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarJugador : MonoBehaviour
{
    // Este valor controlará la sensibilidad del ratón.
    public float sensibilidadRaton;

    //Este valor evitará que la cámara pueda girar 360º.
    private float restriccionEjeX;

    //Obtenemos el GameObject que es el cuerpo del jugador.
    public GameObject cuerpoJugador;

    private void Awake()
    {
        bloquearRaton();
        restriccionEjeX = 0.0f;
    }
    
    /// <summary>
    /// Bloquea el ratón dentro del juego mientras que
    /// el jugador esté siendo controlado.
    /// </summary>
    private void bloquearRaton()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        rotacionCamara();
    }

    /// <summary>
    /// Controlará el movimiento de la cámara desde una
    /// perspectiva en primera persona.
    /// </summary>
    void rotacionCamara()
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
            restringirRotacionEjeXAValor(270.0f);
        }
        else if (restriccionEjeX < -90.0f)
        {
            restriccionEjeX = -90.0f;
            ratonY = 0.0f;
            restringirRotacionEjeXAValor(90.0f);
        }

        /* 
         * Para obtener movimiento en vertical, multiplicamos el Vector3 del eje X de la cámara (eje X en 3D)
         * por el valor ratonY (eje Y en 2D) en el momento en el que el método es llamado. (En este caso, un 
         * Vector3(-1, 0, 0)*valor eje Y del ratón).
         */
        transform.Rotate(Vector3.left * ratonY);
        /*
         * Para obtener el movimiento en horizontal, multiplicamos el Vector3 del eje Y del CUERPO del jugador
         * (aquí lo hacemos del cuerpo del jugador pues ya que cuando giramos la cabeza en la vida real, llegados
         * a un punto, nosotros físicamente acabamos rotando también) (Eje Y en 3D) por el valor ratonX (Eje X en
         * 2D) en el momento en el que el método es llamado. (En este caso, un Vector3(0, 1, 0)*valor eje X del ratón).
         */
        cuerpoJugador.transform.Rotate(Vector3.up * ratonX);
    }

    /// <summary>
    /// Aplica sobre el eje X en los ángulos Euler actuales
    /// el valor especificado.
    /// </summary>
    /// <param name="valor">Valor a aplicar sobre X.</param>
    void restringirRotacionEjeXAValor(float valor)
    {
        Vector3 rotacionEuler = transform.eulerAngles;
        rotacionEuler.x = valor;
        transform.eulerAngles = rotacionEuler;
    }
}
