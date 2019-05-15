using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickParafocus : MonoBehaviour, IPointerDownHandler
{
    #region Variables

    private RectTransform panel;

    #endregion

    #region Métodos Unity

    void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        panel.SetAsLastSibling();
    }

    #endregion
}
