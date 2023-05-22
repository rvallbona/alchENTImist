using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IngredientsList : UserInterface
{
    [SerializeField] private GameObject slotPrefab;

    void Start()
    {
        CreateIngredientsList();
    }

    public void CreateIngredientsList() 
    { 
        List<Ingredient> ingredientsList = DBManager._DB_MANAGER.GetIngredientsList();

        for (int i = 0; i < 12; i++)
        {
            GameObject tempIngredient = Instantiate(slotPrefab, this.transform);
            tempIngredient.GetComponent<IngredientInfo>().SetID(ingredientsList[i].id_ingredient);
            tempIngredient.GetComponent<IngredientInfo>().SetIngredientName(ingredientsList[i].ingredient);
            tempIngredient.GetComponentInChildren<TextMeshProUGUI>().text = ingredientsList[i].ingredient;
        }
    }
}