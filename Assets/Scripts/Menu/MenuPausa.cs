using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private Canvas menuPausa;
    [SerializeField] private MenuPausa menu;

    void Awake()
    {
        // Me aseguro de que solo hay un menú de pausa por instancia de juego.
        if (menu == null)
        {
            menu = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(menuPausa.gameObject);
        }
        else if (menu != this)
        {
            Destroy(menuPausa.gameObject);
            Destroy(gameObject);
        }    
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            menuPausa.gameObject.SetActive(false);
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
    }
}
