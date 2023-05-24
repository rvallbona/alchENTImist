using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [HideInInspector]public int indexOrdersDone;
    public int orderCount;
    [SerializeField] MainMenuControl control;

    [SerializeField] GameObject slot;
    [SerializeField] GameObject order;
    PotionList orders;
    GridLayoutGroup slotGroup;
    GridLayoutGroup orderGroup;
    string nameSlotToCompare;
    string nameOrderToCompare;
    List<int> ids_potions = new List<int>();

    private void Start()
    {
        indexOrdersDone = 0;
        slotGroup = slot.gameObject.GetComponent<GridLayoutGroup>();
        orderGroup = order.gameObject.GetComponent<GridLayoutGroup>();
        orders = order.gameObject.GetComponent<PotionList>();
        ids_potions = DBManager._DB_MANAGER.GetPotionsIDList();
    }
    private void Update()
    {
        for (int i = 0; i < orderGroup.transform.childCount; i++)
        {
            for (int e = 0; e < slotGroup.transform.childCount; e++)
            {
                nameSlotToCompare = slotGroup.transform.GetChild(e).gameObject.GetComponent<TextMeshProUGUI>().text;
                //Debug.Log("Sloted: " + nameSlotToCompare);
            }
            for (int x = 0; x < orderGroup.transform.childCount; x++)
            {
                nameOrderToCompare = orderGroup.transform.GetChild(x).gameObject.GetComponent<TextMeshProUGUI>().text;
                //Debug.Log("Order: " + nameOrderToCompare);
            }
        }
        if (nameSlotToCompare == nameOrderToCompare && orders.listCharger)
        {
            indexOrdersDone += 1;
            //Destruir todos los childs de slot
            for (int i = 0; i < slot.transform.childCount; i++)
            {
                Destroy(slot.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < order.transform.childCount; i++)
            {
                Destroy(order.transform.GetChild(i).gameObject);
            }
            if (indexOrdersDone == 1)
            {
                orders.InstantiateOrderPotion(0);
                orders.InstantiateOrderPotion(1);
            }
            else if (indexOrdersDone == 2)
            {
                orders.InstantiateOrderPotion(2);
                orders.InstantiateOrderPotion(3);
            }
            else if (indexOrdersDone == 3)
            {
                orders.InstantiateOrderPotion(3);
                orders.InstantiateOrderPotion(1);
            }
            else
            {
                indexOrdersDone = 0;
            }
        }

        if (indexOrdersDone == orderCount)
        {
            control.ChangeWinCanvas();
        }
    }
}
