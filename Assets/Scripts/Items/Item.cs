using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Drag")]
    [HideInInspector] public Transform parentAfterDrag;
    private RectTransform rectTransform;
    //prueva
    GameObject listIngredients;
    GridLayoutGroup gridLayoutGroup;
    GameObject originalObject;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalObject = this.gameObject;
        CloneObject();
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

    void CloneObject()
    {
        GameObject clonedObject = Instantiate(originalObject);
        clonedObject.transform.position = originalObject.transform.position;
        clonedObject.transform.SetParent(originalObject.transform.parent, false);

        Ingredient originalComponent = originalObject.GetComponent<Ingredient>();
        Ingredient clonedComponent = clonedObject.GetComponent<Ingredient>();
        clonedComponent.id_ingredient = originalComponent.id_ingredient;
        clonedComponent.name_ingredient = originalComponent.name_ingredient;
    }
}