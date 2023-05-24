using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionList : MonoBehaviour
{
    List<int> ids_potions = new List<int>();
    [SerializeField] GameObject potionPrefab;
    List<string> names_potions = new List<string>();
    [SerializeField] GameObject winManagerGO;
    WinManager winManager = new WinManager();

    GridLayoutGroup orderGridGroup;

    void Start()
    {
        ids_potions = DBManager._DB_MANAGER.GetPotionsIDList();
        winManager = winManagerGO.GetComponent<WinManager>();
        orderGridGroup = this.gameObject.GetComponent<GridLayoutGroup>();
        for (int i = 0; i < ids_potions.Count; i++)
        {
            names_potions.Add(DBManager._DB_MANAGER.GetNamePotion(ids_potions[i]));
        }

        if (winManager.indexOrdersDone == 1)
        {
            InstantiateOrderPotion(0);
            InstantiateOrderPotion(1);
        }
    }
    private void Update()
    {
        Debug.Log(winManager.indexOrdersDone);

        if (winManager.indexOrdersDone == 2)
        {
            for (int i = 0; i < orderGridGroup.transform.childCount; i++)
            {
                Destroy(orderGridGroup.transform.GetChild(i).gameObject);
            }

            InstantiateOrderPotion(2);
            InstantiateOrderPotion(3);
        }

        if (winManager.indexOrdersDone == 3)
        {

            for (int i = 0; i < orderGridGroup.transform.childCount; i++)
            {
                Destroy(orderGridGroup.transform.GetChild(i).gameObject);
            }

            InstantiateOrderPotion(3);
            InstantiateOrderPotion(1);
        }

    }
    void InstantiateOrderPotion(int id_potion)
    {
        GameObject newPotion = Instantiate(potionPrefab, transform.position, transform.rotation) as GameObject;
        newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("ListaPociones").transform, false);
        TextMeshProUGUI newName = newPotion.GetComponent<TextMeshProUGUI>();
        newName.text = names_potions[id_potion];
    }
}