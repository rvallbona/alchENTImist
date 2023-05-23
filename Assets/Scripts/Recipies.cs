using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recipies : MonoBehaviour
{
    #region Variables
    [Header("DB")]
    DBManager dbManager;

    [Header("Potions/Ingredients")]
    public GameObject potion;
    public GameObject ingredient;
    List<int> idPotionsList, idIngredientsList, idPotionsIngredients, idPotions;
    List<string> namePotionsList, nameIngredientsList, idIngredients;

    #region Structs
    public struct potionFormat
    {
        public int id_potion;
        public string name_potion;
    }
    public struct ingredientFormat
    {
        public int id_ingredient;
        public string name_ingredient;
    }
    #endregion
    #endregion
    private void Start()
    {
        #region DB Management
        dbManager = GameObject.FindGameObjectWithTag("dbManager").GetComponent<DBManager>();
        idPotionsList = dbManager.GetPotionIdList();
        namePotionsList = dbManager.GetPotionsNameList();
        idIngredientsList = dbManager.GetIngredientsIdList();
        nameIngredientsList = dbManager.GetIngredientsNameList();
        idPotionsIngredients = dbManager.GetRecipiesIdList();
        idPotions = dbManager.GetRecipiesIdPotionList();
        idIngredients = dbManager.GetRecipiesNameList();
        #endregion
        #region Potions
        for (int i = 0; i < namePotionsList.Count; i++)
        {
            GameObject newPotion = Instantiate(potion, transform.position, transform.rotation) as GameObject;
            newPotion.transform.SetParent(GameObject.FindGameObjectWithTag("Recipie1").transform, false);
            TextMeshProUGUI potiontName = newPotion.GetComponent<TextMeshProUGUI>();
            potionFormat poti = new potionFormat();
            poti.id_potion = idPotionsList[i];
            poti.name_potion = namePotionsList[i];
            potiontName.text = poti.id_potion + "." + poti.name_potion;
        }
        #endregion
        #region Ingredients
        for (int i = 0; i < nameIngredientsList.Count; i++)
        {
            GameObject newIngredient = Instantiate(ingredient, transform.position, transform.rotation) as GameObject;
            newIngredient.transform.SetParent(GameObject.FindGameObjectWithTag("Recipie2").transform, false);
            TextMeshProUGUI ingredientName = newIngredient.GetComponent<TextMeshProUGUI>();
            ingredientFormat ingre = new ingredientFormat();
            ingre.id_ingredient = idIngredientsList[i];
            ingre.name_ingredient = nameIngredientsList[i];
            ingredientName.text = ingre.id_ingredient + "." + ingre.name_ingredient;
        }
        #endregion
    }
}
