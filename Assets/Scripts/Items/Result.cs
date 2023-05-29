using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject potionPrefab;
    public void SpawnPotion(int id_potion)
    {
        GameObject newPotion = Instantiate(potionPrefab, transform.position, transform.rotation) as GameObject;
        newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("ListaResult").transform, false);

        newPotion.gameObject.GetComponent<Potion>().id_potion = id_potion;
        string namePotion = DBManager._DB_MANAGER.GetNamePotion(id_potion);
        newPotion.gameObject.GetComponent<Potion>().name_potion = namePotion;

        TextMeshProUGUI newName = newPotion.GetComponent<TextMeshProUGUI>();
        newName.text = namePotion;
    }
}