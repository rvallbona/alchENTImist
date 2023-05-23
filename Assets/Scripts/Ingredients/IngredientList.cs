using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientList : MonoBehaviour
{
    List<int> ids_ingredients = new List<int>();
    [SerializeField] GameObject ingredientPrefab;
    Ingredient ingredient = new Ingredient();
    private void Start()
    {
        ids_ingredients = DBManager._DB_MANAGER.GetIngredientIDList();

        for (int i = 0; i < ids_ingredients.Count; i++)
        {
            ingredient.name_ingredient = DBManager._DB_MANAGER.GetNameIngredient(ids_ingredients[i]);

            GameObject newIngredient = Instantiate(ingredientPrefab, transform.position, transform.rotation) as GameObject;
            newIngredient.transform.SetParent(GameObject.FindGameObjectWithTag("ListaIngredientes").transform, false);

            newIngredient.gameObject.GetComponent<Ingredient>().id_ingredient = ids_ingredients[i];
            newIngredient.gameObject.GetComponent<Ingredient>().name_ingredient = ingredient.name_ingredient;
            
            TextMeshProUGUI newName = newIngredient.GetComponent<TextMeshProUGUI>();
            newName.text = ingredient.name_ingredient;
        }
    }
}
