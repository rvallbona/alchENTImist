using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    #region Variables
    [Header("DB")]
    [SerializeField] DBManager dbManager;

    [Header("Ingredients")]
    GameObject slotedIngredient;
    TextMeshProUGUI ingredient;
    [HideInInspector] public string[] ingredients_ids;
    [HideInInspector] public string idIngredient;
    [HideInInspector] public List<string> idsIngredientsList;

    [Header("Potions")]
    [SerializeField] Potions potion;
    private int indexPotionIngredients;
    [HideInInspector] public int id_potion_created;
    #endregion
    private void Start()
    {
        id_potion_created = 20;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            slotedIngredient = eventData.pointerDrag;
            eventData.pointerDrag.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;
            slotedIngredient.SetActive(false);
            ingredient = slotedIngredient.GetComponent<TextMeshProUGUI>();
            ingredients_ids = ingredient.text.ToString().Split(".");
            idIngredient = ingredients_ids[0];
            idsIngredientsList.Add(idIngredient);
            indexPotionIngredients += 1;
        }
        if (indexPotionIngredients == 3)
        {
            id_potion_created = dbManager.CheckRecipe(idsIngredientsList);
            potion.SpawnPotion();
            indexPotionIngredients = 0;
        }
    }
}
