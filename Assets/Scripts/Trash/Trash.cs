using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Trash : MonoBehaviour, IDropHandler
{
    [SerializeField] Balance balanceUser;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            balanceUser.RestBalance(5);
            Destroy(eventData.pointerDrag.gameObject);
        }
    }
}
