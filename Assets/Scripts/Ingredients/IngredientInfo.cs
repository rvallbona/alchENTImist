using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngredientInfo : MonoBehaviour
{
    private TextMeshProUGUI ingredientText;
    [SerializeField] private int id_ingredient;
    [SerializeField] private string ingredient;

    void Start()
    {
        ingredientText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetID(int _id) { id_ingredient = _id; }
    public int GetID() { return id_ingredient; }

    public void SetIngredientName(string _ingredient) { ingredient = _ingredient; }
    public string GetIngredientName() { return ingredient; }

    public void SetIngredienText(string _ingredient) { ingredientText.text = _ingredient; }

}
