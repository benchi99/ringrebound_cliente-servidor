using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccionesMenu : MonoBehaviour
{
    
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
