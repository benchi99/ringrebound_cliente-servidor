using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccionesMenu : MonoBehaviour
{
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ToggleWindow (GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
