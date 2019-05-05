using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bounds : NetworkBehaviour
{
    #region Métodos Unity

    void OnTriggerEnter(Collider other)
    {
        TriggerActions(other);
    }

    #endregion

    #region Otros métodos.
    
    /// <summary>
    /// Aquí se llaman todas las funciones que
    /// los triggers de los bordes realizan.
    /// </summary>
    /// <param name="other"></param>
    void TriggerActions(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Projectile":
                // Se destruye el aro.
                NetworkServer.Destroy(other.gameObject);
                break;
            case "Player":
                // Se obtiene el jugador, y se le hace reaparecer.
                var jug = other.GetComponent<Jugador>();

                jug.RpcReaparecer();
                break;
        }
    }

    #endregion
}
