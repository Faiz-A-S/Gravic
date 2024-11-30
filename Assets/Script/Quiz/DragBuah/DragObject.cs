using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _canvas;
    private RectTransform _rectObj;
    private Image _imageObj;

    private void Awake()
    {   
        _imageObj = GetComponent<Image>();
        _imageObj.alphaHitTestMinimumThreshold = 0.001f;
        _canvas = GetComponentInParent<Canvas>();
        _rectObj = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectObj.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }
}
