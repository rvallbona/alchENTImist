using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject mainCanvas;
    private CraftManager m_craft_manager;

    private void Awake()
    {
        m_craft_manager = GameObject.FindGameObjectWithTag("Crafting").GetComponent<CraftManager>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        MouseData.tempItemBeingDragged = Instantiate(this.gameObject, mainCanvas.transform);
        MouseData.tempItemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = false;
        MouseData.tempItemBeingDragged.GetComponentInChildren<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (MouseData.tempItemBeingDragged != null) {
            RectTransform rectTransform = MouseData.tempItemBeingDragged.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (MouseData.mouseOverPanelTransform != null) {
            if (MouseData.mouseOverPanelTransform.name == "Crafting")
            {
                GameObject slotAvailable = MouseData.mouseOverPanelTransform.GetComponent<CraftManager>().FirstSlotAvailable();
                if (slotAvailable != null)
                {
                    slotAvailable.GetComponent<TextMeshProUGUI>().text = MouseData.tempItemBeingDragged.GetComponentInChildren<TextMeshProUGUI>().text;
                    m_craft_manager.AddIngredient(this.gameObject.GetComponent<IngredientInfo>().GetI_ID());
                    m_craft_manager.CheckIngredientBool(true);
                    Destroy(MouseData.tempItemBeingDragged);
                    MouseData.tempItemBeingDragged = null;
                }
                else
                {
                    Destroy(MouseData.tempItemBeingDragged);
                    MouseData.tempItemBeingDragged = null;
                }
            }
            else 
            {
                Destroy(MouseData.tempItemBeingDragged);
                MouseData.tempItemBeingDragged = null;
            }
        }
    }
}
public static class MouseData
{
    public static GameObject tempItemBeingDragged = null;
    public static Transform mouseOverPanelTransform = null;
}
