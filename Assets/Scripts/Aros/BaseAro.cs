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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "levelBounds")
        {
            NetworkServer.Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Ricochet")
        {
            rb.velocity += new Vector3(-rb.velocity.x, 0, -rb.velocity.z);
        }
    }
    
    public void Disparar()
    {
        rb.velocity = transform.forward * velocidad;
    }
    
}