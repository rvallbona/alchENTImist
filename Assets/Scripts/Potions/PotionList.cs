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

    public bool listCharger = false;

    void Start()
    {
        ids_potions = DBManager._DB_MANAGER.GetPotionsIDList();
        winManager = winManagerGO.GetComponent<WinManager>();
        orderGridGroup = this.gameObject.GetComponent<GridLayoutGroup>();
        for (int i = 0; i < ids_potions.Count; i++)
        {
            names_potions.Add(DBManager._DB_MANAGER.GetNamePotion(ids_potions[i]));
        }
        listCharger = true;
    }
    public void InstantiateOrderPotion(int id_potion)
    {
        if (GameObject.FindGameObjectWithTag("ListaPociones") != null)
        {
            GameObject newPotion = Instantiate(potionPrefab, transform.position, transform.rotation) as GameObject;
            newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("ListaPociones").transform, false);
            TextMeshProUGUI newName = newPotion.GetComponent<TextMeshProUGUI>();
            newName.text = names_potions[id_potion];
        }
    }
}