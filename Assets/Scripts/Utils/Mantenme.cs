using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantenme : MonoBehaviour
{
    private static Mantenme _menu;
    public static Mantenme Menu
    {
        get { return _menu; }
    }

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
}
