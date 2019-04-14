using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{
    private string serverName;

    public void EmpezarHost()
    {
        if (serverName == null || serverName == "")
            serverName = "Ring Rebound Server";
        
        base.StartHost();

        print("Partida " + serverName + " iniciada.");
    }

    public void ConectarAPartida()
    {
        base.StartClient();
    }

    public void EstablecerIP(string ip)
    {
        networkAddress = ip;
    }

    public void EstablecerPuerto(string puerto)
    {
        networkPort = int.Parse(puerto);
    }

    public void EstablecerNombrePartida(string nombre)
    {
        serverName = nombre;
    }

    public void DesconectarDePartida()
    {
        if (NetworkServer.connections.Count > 0)
            base.StopHost();
        else
            base.StopClient();
    }
}
