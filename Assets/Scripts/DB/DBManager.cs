using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DBManager : MonoBehaviour
{
    public static DBManager _DB_MANAGER;

    private List<PotionType> potionTypes = new List<PotionType>();
    private List<Potion> potions = new List<Potion>();
    private List<Ingredient> ingredients = new List<Ingredient>();
    private void Awake()
    {
        if (_DB_MANAGER != null && _DB_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else {
            _DB_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        OpenDatabase();
        GetPotionTypes();
        GetPotions();
        GetIngredients();
        /*for (int i = 0; i < potionTypes.Count; i++)
        {
            Debug.Log(potionTypes[i].type);
        }*/
    }

    IDbConnection dbConnection;

    private void OpenDatabase()
    {
        string dbUri = "URI=file:alchENTImist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
    }

    public void GetPotionTypes()
    {
        string query = "SELECT * FROM potion_types";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            PotionType newPotionType = new PotionType();
            newPotionType.id_potion_type = dataReader.GetInt32(0);
            //Debug.Log(newPotionType.id_potion_type);
            newPotionType.type = dataReader.GetString(1);
            //Debug.Log(newPotionType.type);
            newPotionType.icon = dataReader.GetString(2);
            //Debug.Log(newPotionType.icon);
            potionTypes.Add(newPotionType);
        }

    }
    public void GetPotions()
    {
        string query = "SELECT * FROM potions";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            Potion newPotion = new Potion();
            newPotion.id_potion = dataReader.GetInt32(0);
            //Debug.Log(newPotion.id_potion);
            newPotion.potion = dataReader.GetString(1);
            //Debug.Log(newPotion.potion);
            newPotion.cost = dataReader.GetFloat(2);
            //Debug.Log(newPotion.cost);
            newPotion.icon = dataReader.GetString(3);
            //Debug.Log(newPotion.icon);
            newPotion.description = dataReader.GetString(4);
            //Debug.Log(newPotion.description);
            newPotion.id_potion_type = dataReader.GetInt32(5);
            //Debug.Log(newPotion.id_potion_type);
            potions.Add(newPotion);
        }

    }
    public void GetIngredients()
    {
        string query = "SELECT * FROM ingredients";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            Ingredient newIngredient = new Ingredient();
            newIngredient.id_ingredient = dataReader.GetInt32(0);
            //Debug.Log(newIngredient.id_ingredient);
            newIngredient.ingredient = dataReader.GetString(1);
            //Debug.Log(newIngredient.ingredient);
            newIngredient.cost = dataReader.GetFloat(2);
            //Debug.Log(newIngredient.cost);
            newIngredient.icon = dataReader.GetString(3);
            //Debug.Log(newIngredient.icon);
            newIngredient.description = dataReader.GetString(4);
            //Debug.Log(newIngredient.description);

            ingredients.Add(newIngredient);
        }
    }
    public List<int> IngredientsNeeded(int _id_potion)
    {
        string query = "SELECT * FROM potions_ingredients WHERE id_potion=" + _id_potion.ToString();
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        List<int> id_ingredients = new List<int>();
        while (dataReader.Read())
        {

            int ingredient = dataReader.GetInt16(3);
            Debug.Log(ingredient);

            id_ingredients.Add(ingredient);
        }
        return id_ingredients;
    }

    public List<int> CheckFirstIngredientAdded(int _id_ingredient)
    {
        string query = "SELECT * FROM potion_ingredients WHERE id_ingredient=" + _id_ingredient.ToString();
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        List<int> id_potions = new List<int>();
        while (dataReader.Read())
        {

            int ingredient = dataReader.GetInt16(3);
            Debug.Log(ingredient);

            id_potions.Add(ingredient);
        }
        return id_potions;
    }
    public List<int> CheckIngredients(List<int> _id_ingredient)
    {
        string query = "SELECT * FROM potion_ingredients WHERE id_ingredient IN(";

        if (_id_ingredient.Count > 1)
        {
            for (int i = 0; i < _id_ingredient.Count; i++)
            {
                query += _id_ingredient[i];
                if (i + 1 != _id_ingredient.Count)
                {
                    query += ",";
                }
                else
                {
                    query += ")";
                }
            }
        }
        else if (_id_ingredient.Count == 1) {
            query += _id_ingredient[0];

        }
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        List<int> id_potions = new List<int>();
        
        int id_potion = 0;
        int ingredients_quantity = 0;
        while (dataReader.Read())
        {
            int id_potion_temp = dataReader.GetInt16(2);
            if (id_potion == 0) { id_potion = id_potion_temp; }
            if (id_potion != id_potion_temp && ingredients_quantity < 2) {
                id_potion = id_potion_temp;
                ingredients_quantity = 0;
                id_potions.Clear();
            }
            if (id_potion == id_potion_temp)
            {
                int id_ingredient = dataReader.GetInt16(3);
                id_potions.Add(id_ingredient);
                ingredients_quantity++;
                Debug.Log(id_ingredient);
            }

            
        }
        return id_potions;
    }

    public string PotionName(int _id_potion)
    {
        string query = "SELECT * FROM potions WHERE id_potion=" + _id_potion;

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
        string potionName = dataReader.GetString(1);
        return potionName;
    }

    public List<Ingredient> GetIngredientsList() { return ingredients; }
}
