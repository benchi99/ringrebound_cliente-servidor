using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class AccionesMenu : MonoBehaviour
{
    #region Variables

    [SerializeField] private Canvas menu;

    [SerializeField] private Button playButton;
    [SerializeField] private Button disconnectButton;

    #endregion

    #region Métodos de Unity

    void Awake()
    {
        disconnectButton.gameObject.SetActive(false);
    }

    //TODO Buscar alternativa a OnLevelWasLoaded.
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
            GlobalVars.IsInPauseMenu = false;
        }
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && SceneManager.GetActiveScene().name == "Main")
        {
            GlobalVars.IsInPauseMenu = !GlobalVars.IsInPauseMenu;

            menu.gameObject.SetActive(!menu.gameObject.activeSelf);

            if (GlobalVars.IsInPauseMenu)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    #endregion

    #region Otros métodos

    /// <summary>
    /// Cierra el juego.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// Activa o desactiva una ventana/GameObject
    /// </summary>
    /// <param name="panel">El panel a mostrar/ocultar.</param>
    public void ToggleWindow (GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    #endregion
}
