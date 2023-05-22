using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInterface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseData.mouseOverPanelTransform = this.gameObject.transform;
        Debug.Log(MouseData.mouseOverPanelTransform.gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
