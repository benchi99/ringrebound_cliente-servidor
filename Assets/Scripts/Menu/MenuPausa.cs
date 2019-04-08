using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private Canvas menuPausa;

    private static MenuPausa _menu;
    public static MenuPausa Menu
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
            DontDestroyOnLoad(menuPausa.gameObject);
        }
        else
        {
            Destroy(menuPausa.gameObject);
            Destroy(gameObject);
        }    
    }
    
    // Update is called once per frame
    void Update()
    {
        //Activa y desactiva el menú de pausa con el botón de escape.
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && SceneManager.GetActiveScene().name == "Main")
        {
            Cursor.lockState = CursorLockMode.None;
            menuPausa.gameObject.SetActive(!menuPausa.gameObject.activeSelf);
        }

        //Se asegura de que en el menú principal el menú de pausa no pueda aparecer.
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            menuPausa.gameObject.SetActive(false);
        }

    }
}
