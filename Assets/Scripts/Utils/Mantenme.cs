using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encarga de mantener entre escenas
/// los GameObjects que tengan este Script.
/// </summary>
public class Mantenme : MonoBehaviour
{
    #region Variables

    private static Mantenme _menu;
    public static Mantenme Menu
    {
        get { return _menu; }
    }

    #endregion

    #region Métodos Unity

    void Awake()
    {
        // Me aseguro de que solo hay un menú de pausa por instancia de juego.
        if (_menu == null)
        {
            _menu = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
