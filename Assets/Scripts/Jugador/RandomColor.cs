using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RandomColor : NetworkBehaviour
{
    #region Variables
    
    // Materials that the game will give to each player randomly.
    public Material material1, material2, material3, material4, material5;
    Material[] colors;

    #endregion

    #region Métodos Unity

    void Awake()
    {
        colors = new Material[] { material1, material2, material3, material4, material5 };    
    }

    // Start is called before the first frame update
    void Start()
    {
        Renderer rnd = GetComponent<Renderer>();
        rnd.material = colors[Random.Range(0, colors.Length)];
    }
    
    #endregion
}
