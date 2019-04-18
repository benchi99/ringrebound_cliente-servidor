using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// CLASS SOURCE: 
/// https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html
/// </summary>
public class FuerzaImpacto : NetworkBehaviour
{
    #region Variables

    [SerializeField] float masa = 3f;
    Vector3 impacto = Vector3.zero;
    private CharacterController chControl;

    #endregion

    #region Metodos Unity

    // Start is called before the first frame update
    void Start()
    {
        chControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Se aplica la fuerza de impacto
        if (impacto.magnitude > 0.2F)
            chControl.Move(impacto * Time.deltaTime);

        impacto = Vector3.Lerp(impacto, Vector3.zero, 5 * Time.deltaTime);
    }
    #endregion

    #region Otros métodos

    /// <summary>
    /// Añade fuerza de impacto al CharacterController.
    /// </summary>
    /// <param name="direccion">La direccion.</param>
    /// <param name="fuerza">La fuerza.</param>

    public void AddImpact(Vector3 direccion, float fuerza)
    {
        direccion.Normalize();

        if (direccion.y < 0)
            direccion.y = -direccion.y;

        impacto += direccion.normalized * fuerza / masa;
    }
    
    #endregion
}
