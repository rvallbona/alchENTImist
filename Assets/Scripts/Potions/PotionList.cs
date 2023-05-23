using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionList : MonoBehaviour
{
    List<int> ids_potions = new List<int>();
    [SerializeField] GameObject potionPrefab;
    Potion potion = new Potion();
    private void Start()
    {
        ids_potions = DBManager._DB_MANAGER.GetPotionsIDList();

        for (int i = 0; i < ids_potions.Count; i++)
        {
            potion.name_potion = DBManager._DB_MANAGER.GetNamePotion(ids_potions[i]);

            GameObject newPotion = Instantiate(potionPrefab, transform.position, transform.rotation) as GameObject;
            newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("ListaPociones").transform, false);
            TextMeshProUGUI newName = newPotion.GetComponent<TextMeshProUGUI>();
            newName.text = potion.name_potion;
        }
    }
}