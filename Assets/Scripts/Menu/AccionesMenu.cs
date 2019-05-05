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

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelLoadEvents;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelLoadEvents;
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

    /// <summary>
    /// Listener de sceneLoaded.
    /// </summary>
    /// <param name="scene">Escena.</param>
    /// <param name="mode">Modo de carga de la Escena.</param>
    void LevelLoadEvents(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            playButton.gameObject.SetActive(true);
            disconnectButton.gameObject.SetActive(false);
        }
        else if (scene.name == "Main")
        {
            menu.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            disconnectButton.gameObject.SetActive(true);
            GlobalVars.IsInPauseMenu = false;
        }
    }

    #endregion
}
