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

    bool checkCompare = false;
    bool hasIncremented;

    private void Start()
    {
        indexOrdersDone = 0;
        slotGroup = slot.gameObject.GetComponent<GridLayoutGroup>();
        orderGroup = order.gameObject.GetComponent<GridLayoutGroup>();
        orders = order.gameObject.GetComponent<PotionList>();
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
        if (nameSlotToCompare == nameOrderToCompare)
        {
            checkCompare = true;

            //Destruir todos los childs de slot
            for (int i = 0; i < slotGroup.transform.childCount; i++)
            {
                Destroy(slotGroup.transform.GetChild(i).gameObject);
            }
        }
        if (checkCompare)
        {
            checkCompare = false;
            if (!hasIncremented)
            {
                sumIndex();
                hasIncremented = true;
            }
        }

        if (indexOrdersDone == orderCount)
        {
            Debug.Log("WIN");
            //control.ChangeWinCanvas();
        }
    }
    public void sumIndex()
    {
        indexOrdersDone += 1;
    }
}
