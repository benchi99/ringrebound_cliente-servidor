using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    [SerializeField] private float velocidad = 5;
    private CharacterController controlJugador;

    private void Awake()
    {
        controlJugador = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movimientoJugador();
    }

    void movimientoJugador()
    {
        float entradaVertical = Input.GetAxis("Vertical") * velocidad;
        float entradaHorizontal = Input.GetAxis("Horizontal") * velocidad;

        Vector3 movimientoHaciaDelante = transform.forward * entradaVertical;
        Vector3 movimientoADerecha = transform.right * entradaHorizontal;

        controlJugador.SimpleMove(movimientoHaciaDelante + movimientoADerecha);
    }

}
