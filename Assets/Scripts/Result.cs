using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Result : MonoBehaviour
{
    #region Variables
    [Header("DB")]
    DBManager dbManager;

    [Header("Potions")]
    public GameObject potion;
    List<string> namePotionsList;
    List<int> idPotionsList;
    [SerializeField] Slot slot;
    public struct potionFormat
    {
        public int id_potion;
        public string name_potion;
    }
    #endregion
    void Start()
    {
        dbManager = GameObject.FindGameObjectWithTag("dbManager").GetComponent<DBManager>();
        idPotionsList = dbManager.GetPotionIdList();
        namePotionsList = dbManager.GetPotionsNameList();
        for (int i = 0; i < namePotionsList.Count; i++)
        {
            GameObject newPotion = Instantiate(potion, transform.position, transform.rotation) as GameObject;
            newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("ListaPociones").transform, false);
            newPotion.SetActive(false);
            TextMeshProUGUI potiontName = newPotion.GetComponent<TextMeshProUGUI>();

            potionFormat poti = new potionFormat();
            poti.id_potion = idPotionsList[i];
            poti.name_potion = namePotionsList[i];
            potiontName.text = poti.id_potion + "." + poti.name_potion;
        }
    }
    public void SpawnPotion()
    {
        for (int i = 0; i < idPotionsList.Count; i++)
        {
            if (slot.id_potion_created == idPotionsList[i])
            {
                GameObject newPotion = Instantiate(potion, transform.position, transform.rotation) as GameObject;
                newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("ListaResult").transform, false);
                TextMeshProUGUI potiontName = newPotion.GetComponent<TextMeshProUGUI>();
                potionFormat poti = new potionFormat();
                poti.id_potion = idPotionsList[i];
                poti.name_potion = namePotionsList[i];
                potiontName.text = poti.id_potion + "." + poti.name_potion;
            }
        }
    }
}