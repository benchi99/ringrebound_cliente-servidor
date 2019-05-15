using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Esta clase es una clase base 
/// de los aros. Esta deberá ser extendida
/// a la hora de realizar modificaciones a
/// los aros.
/// </summary>
public class BaseAro : NetworkBehaviour
{
    #region Variables

    [SerializeField] float velocidad;
    [SerializeField] int delayDisparo;

    private float timerTag = 1f;
    private Rigidbody rb;

    #endregion

    #region Metodos Unity

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time >= timerTag)
            gameObject.tag = "Projectile";
    }

    #endregion

    #region Otros métodos

    /// <summary>
    /// Añade velocidad del Rigidbody del aro.
    /// </summary>
    public void Disparar()
    {
        rb.velocity = transform.forward * velocidad;
    }

    #endregion

}