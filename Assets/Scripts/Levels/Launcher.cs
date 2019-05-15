using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Script que se encarga de la funcionalidad de
/// los lanzadores.
/// </summary>
public class Launcher : NetworkBehaviour
{
    #region Variables

    //Fuerza del lanzador.
    [SerializeField] private float fuerza = 65f;
    //Altura que va a alcanzar.
    [SerializeField] private float dirEjeY = 0.3f;

    #endregion

    #region Métodos Unity

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Lanzar(other.gameObject);
    }

    #endregion

    #region Otros métodos

    /// <summary>
    /// Método que aplica una fuerza para poder
    /// lanzarlo.
    /// </summary>
    /// <param name="gameObject">El Jugador.</param>
    void Lanzar(GameObject gameObject)
    {
        //Sé que lo que va a llegar aquí siempre será un jugador.
        var jug = gameObject.GetComponent<Jugador>();
        //Calculo el vector de lanzamiento.
        Vector3 launchVector = new Vector3(transform.forward.x, dirEjeY, transform.forward.z);

        //Lanzo al jugador.
        jug.Lanzar(launchVector, fuerza);
    }
    
    #endregion
}
