using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bounds : NetworkBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Projectile":
                NetworkServer.Destroy(other.gameObject);
                break;
            case "Player":
                var jug = other.GetComponent<Jugador>();

                jug.RpcReaparecer();
                break;
        }    
    }
}
