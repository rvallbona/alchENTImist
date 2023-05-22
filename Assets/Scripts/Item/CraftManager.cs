using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CraftManager : UserInterface
{
    [SerializeField] private GameObject[] slots; 
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private List<int> id_ingredients_onCraft;
    [SerializeField] private bool checkIngredient;

    private void Awake()
    {
        result = GameObject.FindGameObjectWithTag("Result").GetComponentInChildren<TextMeshProUGUI>();
    }
    void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<TextMeshProUGUI>().text = "";
        }
        checkIngredient = false;
        id_ingredients_onCraft = new List<int>();
    }
    void Update()
    {
        if (checkIngredient) {
            checkIngredient = false;
            // > 1 if no potion crafteable with 1 ingredient
            if (id_ingredients_onCraft.Count > 1) {
                List<int> id_potions = DBManager._DB_MANAGER.CheckIngredients(id_ingredients_onCraft);
                if (id_potions.Count == 1) 
                {
                    //Check if potion needs more ingredients
                    List<int> id_ingredients = DBManager._DB_MANAGER.IngredientsNeeded(id_potions[0]);
                    if (id_ingredients.Count == id_ingredients_onCraft.Count) {
                        //Check ids
                        int ingredientsMatch = 0;
                        for (int i = 0; i < id_ingredients.Count; i++)
                        {
                            Debug.Log(id_ingredients[i].ToString());
                            for (int j = 0; j < id_ingredients_onCraft.Count; j++)
                            {
                                if (id_ingredients_onCraft[j] == id_ingredients[i]) {
                                    ingredientsMatch++;
                                }
                            }
                        }
                        if (ingredientsMatch == id_ingredients.Count) {
                            result.text = DBManager._DB_MANAGER.PotionName(id_potions[0]);
                        }
                        
                    }
                }
                else if (id_potions.Count > 1) 
                {
                    //Check if any potion meets all ingredients required
                    
                }
            }
            
        }
    }
    public void CheckIngredientBool(bool check) {
        checkIngredient = check;
    }
    public void AddIngredient(int id_ingredient) {
        id_ingredients_onCraft.Add(id_ingredient);
    }
    public GameObject FirstSlotAvailable() {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<TextMeshProUGUI>().text == "") { return slots[i]; }
        }
        return null;
    }
}
