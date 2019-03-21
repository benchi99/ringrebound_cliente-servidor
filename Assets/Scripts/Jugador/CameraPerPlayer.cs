using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!this.transform.parent.GetComponent<Jugador>().isLocalPlayer)
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioBehaviour>().enabled = false;
        }       
    }
}
