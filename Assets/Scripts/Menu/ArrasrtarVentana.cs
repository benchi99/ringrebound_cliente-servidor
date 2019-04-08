using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrasrtarVentana : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    private Vector2 offsetPuntero;
    private RectTransform rectTransformCanvas;
    private RectTransform rectTransformPanel;

    void Awake()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            rectTransformCanvas = canvas.transform as RectTransform;
            rectTransformPanel = transform.parent as RectTransform;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransformPanel == null)
            return;

        Vector2 posPuntero = AgarrarAVentana(eventData);

        Vector2 posicionLocalPuntero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransformCanvas, posPuntero, eventData.pressEventCamera, out posicionLocalPuntero))
        {
            rectTransformPanel.localPosition = posicionLocalPuntero - offsetPuntero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransformPanel.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransformPanel, eventData.position, eventData.pressEventCamera, out offsetPuntero);
    }

    Vector2 AgarrarAVentana (PointerEventData eventData)
    {
        Vector2 posRaton = eventData.position;

        Vector3[] esquinasCanvas = new Vector3[4];
        rectTransformCanvas.GetWorldCorners(esquinasCanvas);

        float agarreX = Mathf.Clamp(posRaton.x, esquinasCanvas[0].x, esquinasCanvas[2].x);
        float agarreY = Mathf.Clamp(posRaton.y, esquinasCanvas[0].y, esquinasCanvas[2].y);

        return new Vector2(agarreX, agarreY);

    }
}
