using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Variables
    [Header("Drag")]
    [HideInInspector] public Transform parentAfterDrag;
    private RectTransform rectTransform;
    #endregion
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    #region DragFuncions
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    #endregion
}