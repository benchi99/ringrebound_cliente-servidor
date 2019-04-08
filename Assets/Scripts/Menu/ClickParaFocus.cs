using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickParafocus : MonoBehaviour, IPointerDownHandler
{
    private RectTransform panel;
    
    void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        panel.SetAsLastSibling();
    }
    
}
