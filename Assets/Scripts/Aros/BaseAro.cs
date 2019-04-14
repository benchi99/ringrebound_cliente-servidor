using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//TODO MODIFICAR CLASE IGUAL CAPTURA

public class BaseAro : NetworkBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] int delayDisparo;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "levelBounds")
        {
            print("Hit!");
            NetworkServer.Destroy(this.gameObject);
        }
    }
    
    public void Disparar()
    {
        rb.velocity = transform.forward * velocidad;
    }
    
}