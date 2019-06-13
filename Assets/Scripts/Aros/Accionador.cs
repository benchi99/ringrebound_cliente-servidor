using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Esta clase controla el punto en donde
/// los proyectiles aparecen, así como el 
/// botón que los acciona.
/// </summary>

public class Accionador : NetworkBehaviour
{
    #region Variables

    [SerializeField] private float cadencia = 7f;
    [SerializeField] private int stockMax = 3;
    [SerializeField] private BaseAro prefabAro;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private Text stockUI;
    
    private float tiempoVolverDisparar;
    private float tiempoVolverDarAro;
    private float tiempoRecargaAro = 4f;
    private int stock;

    #endregion

    #region Metodos Unity

    void OnEnable()
    {
        stock = stockMax;
        tiempoVolverDarAro = tiempoRecargaAro;
        stockUI.text = "Rings: " + stock;
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            stockUI.gameObject.SetActive(true);
        }
        else
        {
            stockUI.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        tiempoVolverDisparar -= Time.deltaTime;
        tiempoVolverDarAro -= Time.deltaTime;

        if (PuedeDisparar())
        {
            CmdDisparo();
            stock--;
            tiempoVolverDisparar = cadencia;
        }

        if (PuedeRegeneraAro())
        {
            stock++;
            tiempoVolverDarAro = tiempoRecargaAro;
        }

        stockUI.text = "RINGS: " + stock;
    }

    #endregion

    #region Otros métodos

    /// <summary>
    /// Comprueba si el jugador puede disparar.
    /// </summary>
    /// <returns>Si puede disparar.</returns>
    bool PuedeDisparar()
    {
        return tiempoVolverDisparar <= 0 && 
            stock > 0 && 
            Input.GetKeyDown(KeyCode.Space);
    }

    /// <summary>
    /// Controla si se puede regenerar un aro o no.
    /// </summary>
    /// <returns>Si puede generar un aro.</returns>
    bool PuedeRegeneraAro()
    {
        return tiempoVolverDarAro <= 0 &&
            stock < 3;
    }

    /// <summary>
    /// Dice al servidor del juego que dispare un aro.
    /// </summary>
    [Command]
    void CmdDisparo()
    {
        var proyectil = Instantiate(prefabAro, puntoDisparo.position, puntoDisparo.rotation);
        NetworkServer.Spawn(proyectil.gameObject);
        proyectil.Disparar();
    }

    #endregion

}
