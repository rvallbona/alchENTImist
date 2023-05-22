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

    //Getters
    public int GetI_ID() { return id_ingredient; }
    public string GetI_Name() { return ingredient; }

    //Setters
    public void SetI_ID(int _id) { id_ingredient = _id; }
    public void SetI_Name(string _ingredient) { ingredient = _ingredient; }
    public void SetI_Text(string _ingredient) { ingredientText.text = _ingredient; }
}
