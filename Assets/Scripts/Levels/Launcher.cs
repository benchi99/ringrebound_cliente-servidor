using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Launcher : NetworkBehaviour
{
    #region Variables

    [SerializeField] private float fuerza = 5;
    [SerializeField] private float dirEjeY = 10;

    #endregion

    #region Métodos Unity

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Lanzar(other.gameObject);
    }

    #endregion

    #region Otros métodos


    void Lanzar(GameObject gameObject)
    {
        var jug = gameObject.GetComponent<Jugador>();
        Vector3 launchVector = new Vector3(transform.forward.x, dirEjeY, transform.forward.z);

        jug.Lanzar(launchVector, fuerza);
    }
    
    #endregion
}
