using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Linq;

public class Slot : MonoBehaviour, IDropHandler
{
    GameObject slotedIngredient;
    List<int> idsPotionsFromIngredients = new List<int>();
    [SerializeField] GameObject result;

    int id_potion_toSpawn;
    bool canSpawnPotion;
    int indexPotionIngredients;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            slotedIngredient = eventData.pointerDrag;
            slotedIngredient.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;

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