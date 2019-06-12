using Assets.Scripts.Modelos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerButton : MonoBehaviour
{

    private Servidor servidor;

    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text servernametext;
    [SerializeField]
    private Text servermaxnumplayers;

    void Start()
    {
        servernametext.text = "Retrieveing information...";
        servermaxnumplayers.text = "Max Players: 0";

        btn.onClick.AddListener(Conectar);
    }

    public void SetInfo(Servidor servidor)
    {
        this.servidor = servidor;

        servernametext.text = servidor.name;
        servermaxnumplayers.text = "Max Players: " + servidor.number_players;
    }

    void Conectar()
    {
        var nwmngr = FindObjectsOfType<CustomNetworkManager>()[0];

        nwmngr.ConectarseA(this.servidor.ip_address, this.servidor.port);
    }
    



}
