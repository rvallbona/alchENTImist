using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Linq;
using Unity.VisualScripting;

public class Slot : MonoBehaviour, IDropHandler
{
    GameObject slotedIngredient;
    List<int> idsPotionsFromIngredients = new List<int>();
    [SerializeField] GameObject result;

    int id_potion_toSpawn;
    bool canSpawnPotion;
    int indexPotionIngredients;
    GridLayoutGroup gridLayoutGroup;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            gridLayoutGroup = this.GetComponent<GridLayoutGroup>();
            slotedIngredient = eventData.pointerDrag;
            slotedIngredient.transform.SetParent(this.GetComponent<GridLayoutGroup>().transform);

            id_potion_toSpawn = slotedIngredient.gameObject.GetComponent<Ingredient>().id_ingredient;

            idsPotionsFromIngredients.Add(DBManager._DB_MANAGER.CheckIdPotionFromIngredientDropped(id_potion_toSpawn));

            canSpawnPotion = false;
            //Comparar la lista que si los numeros de dentro son los mismos pues podemos spawnear la pocion con esa id
            if (CheckRecipe(idsPotionsFromIngredients))
            {
                canSpawnPotion = true;
            }
            else
            {
                canSpawnPotion = false;
            }
            indexPotionIngredients += 1;
            if (gridLayoutGroup.transform.childCount == 3)
            {
                for (int i = 0; i < gridLayoutGroup.transform.childCount; i++)
                {
                    Debug.Log("hola");
                    Destroy(gridLayoutGroup.transform.GetChild(i).gameObject);
                }
            }
        }
        if (indexPotionIngredients == 3 && canSpawnPotion)
        {
            indexPotionIngredients = 0;
            canSpawnPotion = false;
            result.gameObject.GetComponent<Result>().SpawnPotion(idsPotionsFromIngredients[0]);
            idsPotionsFromIngredients.Clear();
        }
        else if (indexPotionIngredients == 3 && !canSpawnPotion)
        {
            indexPotionIngredients = 0;
            idsPotionsFromIngredients.Clear();
        }
    }

    bool CheckRecipe(List<int> numeros){
        if (numeros.Count == 0)
            return true;
        int primerNumero = numeros[0];
        foreach (int num in numeros)
            if (num != primerNumero)
                return false;
        return true;
    }
}