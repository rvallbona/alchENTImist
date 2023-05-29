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
    List<int> idsIngredientsForCheck = new List<int>();
    [SerializeField] GameObject result;

    int id_potion_toSpawn;
    bool canSpawnPotion;
    bool isntSame;
    int indexPotionIngredients;
    GridLayoutGroup gridLayoutGroup;

    [SerializeField] Balance balanceUser;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            balanceUser.RestBalance(5);
            gridLayoutGroup = this.GetComponent<GridLayoutGroup>();
            slotedIngredient = eventData.pointerDrag;
            slotedIngredient.transform.SetParent(this.GetComponent<GridLayoutGroup>().transform);

            id_potion_toSpawn = slotedIngredient.gameObject.GetComponent<Ingredient>().id_ingredient;
            idsIngredientsForCheck.Add(slotedIngredient.gameObject.GetComponent<Ingredient>().id_ingredient);

            idsPotionsFromIngredients.Add(DBManager._DB_MANAGER.CheckIdPotionFromIngredientDropped(id_potion_toSpawn));

            canSpawnPotion = false;
            isntSame = false;

            if (CheckIdsIngredients(idsIngredientsForCheck) && CheckRecipe(idsPotionsFromIngredients))
            {
                canSpawnPotion = true;
                isntSame = true;
            }
            else
            {
                canSpawnPotion = false;
                isntSame = false;
            }
            indexPotionIngredients += 1;
            if (gridLayoutGroup.transform.childCount == 3)
            {
                for (int i = 0; i < gridLayoutGroup.transform.childCount; i++)
                {
                    Destroy(gridLayoutGroup.transform.GetChild(i).gameObject);
                }
            }
        }
        if (indexPotionIngredients == 3 && canSpawnPotion && isntSame)
        {
            indexPotionIngredients = 0;
            canSpawnPotion = false;
            isntSame = false;
            result.gameObject.GetComponent<Result>().SpawnPotion(idsPotionsFromIngredients[0]);
            idsPotionsFromIngredients.Clear();
            idsIngredientsForCheck.Clear();
        }
        else if (indexPotionIngredients == 3 && !canSpawnPotion && !isntSame)
        {
            indexPotionIngredients = 0;
            idsPotionsFromIngredients.Clear();
            idsIngredientsForCheck.Clear();
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
    bool CheckIdsIngredients(List<int> numeros)
    {
        HashSet<int> numerosUnicos = new HashSet<int>(numeros);
        return numerosUnicos.Count == numeros.Count;
    }
}