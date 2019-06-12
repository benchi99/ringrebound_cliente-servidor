using Assets.Scripts;
using Assets.Scripts.Modelos;
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Assets.Scripts.Utils;

public class ServerBrowser : MonoBehaviour
{

    [SerializeField]
    GameObject ButtonPrefab;

    [SerializeField]
    Image ListContents;

    public void RetrieveServers()
    {
        StartCoroutine(GetServers());
    }

    IEnumerator GetServers()
    {
        UnityWebRequest getsv = UnityWebRequest.Get(GlobalVars.BASE_WEBURL);
        yield return getsv.SendWebRequest();

        if (getsv.isNetworkError || getsv.isHttpError)
        {
            DisplayError(getsv.error);
        }
        else
        {
            FillServerList(getsv.downloadHandler.text);
        }
    }

    private void DisplayError(string error)
    {
        throw new NotImplementedException();
    }

    void FillServerList(string text)
    {
        List<Servidor> servidores = ServerJsonParser.Parse(text);

        foreach (Servidor servidor in servidores)
        {
            print(servidor.name);
            var btn = Instantiate(ButtonPrefab);
            btn.gameObject.transform.SetParent(ListContents.gameObject.transform);
            ServerButton svbt = btn.GetComponent<ServerButton>();
            svbt.SetInfo(servidor);
        }
        
        
    }
}
