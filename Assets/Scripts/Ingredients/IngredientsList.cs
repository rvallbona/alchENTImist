using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IngredientsList : UserInterface
{
    [SerializeField] private GameObject slotPrefab;
    List<Ingredient> ingredientsList;

    void Start()
    {
        CreateIngredientsList(); 
    }

    public void CreateIngredientsList() 
    {
        ingredientsList = DBManager._DB_MANAGER.GetIngredientsList();

        for (int i = 0; i < 4; i++)
        {
            GameObject tempIngredient = Instantiate(slotPrefab, this.transform);
            tempIngredient.GetComponent<IngredientInfo>().SetI_ID(ingredientsList[i].id_ingredient);
            tempIngredient.GetComponent<IngredientInfo>().SetI_Name(ingredientsList[i].ingredient);
            tempIngredient.GetComponentInChildren<TextMeshProUGUI>().text = ingredientsList[i].ingredient;
        }
    }
}