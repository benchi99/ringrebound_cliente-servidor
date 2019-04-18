using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BaseAro : NetworkBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] int delayDisparo;

    private float timerTag = 1f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time >= timerTag)
            gameObject.tag = "Projectile";
    }
    
    public void Disparar()
    {
        rb.velocity = transform.forward * velocidad;
    }
    
}