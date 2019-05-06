using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RandomColor : NetworkBehaviour
{
    public Material material1, material2, material3, material4, material5;
    Material[] colors;

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
}
