using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Clase que extiende a NetworkManager, para que
/// mi interfaz pueda interactuar con el mismo
/// NetworkManager.
/// </summary>
public class CustomNetworkManager : NetworkManager
{
    private string serverName;

    /// <summary>
    /// Aloja una partida del juego.
    /// </summary>
    public void EmpezarHost()
    {
        if (serverName == null || serverName == "")
            serverName = "Ring Rebound Server";
        
        base.StartHost();

        print("Partida " + serverName + " iniciada.");
    }

    /// <summary>
    /// Se conecta a una partida.
    /// </summary>
    public void ConectarAPartida()
    {
        base.StartClient();
    }

    /// <summary>
    /// Establece la ip.
    /// </summary>
    /// <param name="ip">La ip.</param>
    public void EstablecerIP(string ip)
    {
        networkAddress = ip;
    }

    /// <summary>
    /// Establece el puerto.
    /// </summary>
    /// <param name="puerto">El puerto.</param>
    public void EstablecerPuerto(string puerto)
    {
        networkPort = int.Parse(puerto);
    }

    /// <summary>
    /// Establece el nombre de la partida.
    /// </summary>
    /// <param name="nombre">El nombre.</param>
    public void EstablecerNombrePartida(string nombre)
    {
        serverName = nombre;
    }

    /// <summary>
    /// Desconecta al jugador de la partida.
    /// </summary>
    public void DesconectarDePartida()
    {
        if (NetworkServer.connections.Count > 0)
            base.StopHost();
        else
            base.StopClient();
    }
}
