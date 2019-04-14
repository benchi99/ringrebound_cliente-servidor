using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//TODO Terminar clase

public class Accionador : NetworkBehaviour
{
    [SerializeField] private float cadencia = 7f;
    [SerializeField] private int stockMax = 3;
    [SerializeField] private BaseAro prefabAro;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private Text stockUI;
    
    private float tiempoVolverDisparar;
    private float tiempoVolverDarAro;
    private float tiempoRecargaAro = 4f;
    private int stock;
    
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
        if(PuedeRegeneraAro())
        {
            stock++;
            tiempoVolverDarAro = tiempoRecargaAro;
        }

        stockUI.text = "Rings: " + stock;
    }

    bool PuedeDisparar()
    {
        return tiempoVolverDisparar <= 0 && 
            stock > 0 && 
            Input.GetKeyDown(KeyCode.Space);
    }

    bool PuedeRegeneraAro()
    {
        return tiempoVolverDarAro <= 0 &&
            stock < 3;
    }

    [Command]
    void CmdDisparo()
    {
        var proyectil = Instantiate(prefabAro, puntoDisparo.position, puntoDisparo.rotation);
        NetworkServer.Spawn(proyectil.gameObject);
        proyectil.Disparar();
    }
}
