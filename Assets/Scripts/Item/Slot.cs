using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item;

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            item = DraggableItem.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }
    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
    }
}
