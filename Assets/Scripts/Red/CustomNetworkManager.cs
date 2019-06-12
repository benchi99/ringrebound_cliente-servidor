using Assets.Scripts;
using System;
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
    private bool publicsv = false;

    private string serverName;

    void Start()
    {
        if (Application.isBatchMode)
        {
            BatchModeProcedure();
        }   
    }
    
    /// <summary>
    /// Aloja una partida del juego.
    /// </summary>
    /// 
    public void EmpezarHost()
    {
        if (serverName == null || serverName == "")
            serverName = "Ring Rebound Server";
        
        base.StartHost();

        print("Partida " + serverName + " iniciada.");

        if (publicsv)
        {
            StartCoroutine(PostPresence());
        }
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

    public void ConectarseA(string ip, int puerto)
    {
        networkAddress = ip;
        networkPort = puerto;
        base.StartClient();
    }

    public void TogglePublicServer(bool value)
    {
        publicsv = value;
    }

    public void EstablecerNumJugadores(string numjug)
    {
        maxConnections = int.Parse(numjug);
    }

    private void OnApplicationQuit()
    {
        if (GlobalVars.serverId != 0)
        {
            StartCoroutine(TerminatePresence());
        }
    }

    void BatchModeProcedure()
    {
        Console.WriteLine("Starting server...");
        Console.WriteLine("Please type a server name, or leave blank for default. (Default: Ring Rebound Server).");
        string svName = Console.ReadLine();

        Console.WriteLine("Please type server port, or leave blank for default. (Default: 7777).");
        string port = Console.ReadLine();

        Console.WriteLine("Do you want the server to be available to the public? This requires the previously specified port to be forwarded in your router. (Yes/No)");
        string avpublic = Console.ReadLine();

        if (svName != "")
        {
            serverName = svName;
        }

        if (port != "")
        {
            networkPort = int.Parse(port);
        }

        publicsv = (avpublic.ToLower() == "yes") ? true : false;

        if (serverName == null || serverName == "")
            serverName = "Ring Rebound Server";

        base.StartServer();
        Console.WriteLine("Partida " + serverName + " iniciada en el puerto " + networkPort + ".");

        if (publicsv)
        {
            StartCoroutine(PostPresence());
        }

    }

    IEnumerator PostPresence()
    {        
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("name", serverName));
        form.Add(new MultipartFormDataSection("number_players", maxConnections.ToString()));
        form.Add(new MultipartFormDataSection("port", networkPort.ToString()));

        UnityWebRequest http = UnityWebRequest.Post(GlobalVars.BASE_WEBURL, form);
        // Se realiza la petición HTTP.
        yield return http.SendWebRequest();
        
        if (http.isNetworkError || http.isHttpError)
        {
            // Si hay error, se imprime el código de error, así como la respuesta.
            Debug.LogError(http.error);
            Debug.LogError(http.downloadHandler.text);
        }
        else
        {
            // Obtenemos la respuesta, y guardamos el ID de servidor que se nos ha asignado.
            string response = http.downloadHandler.text;
            print(response);
            string id = response.Substring(response.LastIndexOf(':'), response.IndexOf('}'));
            GlobalVars.serverId = int.Parse(id);
        }
    }

    IEnumerator TerminatePresence()
    {
        yield return null;
    }
}
