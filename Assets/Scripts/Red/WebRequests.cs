using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequests : MonoBehaviour
{
    public void retrieveServers()
    {
        StartCoroutine(getServers());
    }

    IEnumerator getServers()
    {
        UnityWebRequest www = UnityWebRequest.Get(GlobalVars.BASE_WEBURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}