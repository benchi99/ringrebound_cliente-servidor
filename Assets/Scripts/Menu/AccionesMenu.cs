using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccionesMenu : MonoBehaviour
{

    [SerializeField] private Canvas menu;

    [SerializeField] private Button playButton;
    [SerializeField] private Button disconnectButton;

    void Awake()
    {
        disconnectButton.gameObject.SetActive(false);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            playButton.gameObject.SetActive(true);
            disconnectButton.gameObject.SetActive(false);
        }
        else if (level == 1)
        {
            menu.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            disconnectButton.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Main")
        {
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);

            if (menu.gameObject.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    //Este método se llama cuando se quiere cerrar el juego.
    public void ExitGame()
    {
        Application.Quit();
    }

    //Este método simplemente activa y desactiva la ventana 
    //a la que es pasada por parámetros
    public void ToggleWindow (GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
