using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using System.Collections.Generic;
public class DBManager : MonoBehaviour
{
    public static DBManager _DB_MANAGER;

    IDbConnection dbConnection;

    [Header("Login")]
    [HideInInspector] public List<int> id_user = new List<int>();
    [HideInInspector] public List<string> name_user = new List<string>();

    private void Awake()
    {
        if (_DB_MANAGER != null && _DB_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _DB_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }

        OpenDatabase();
        Login();
    }
    private void OpenDatabase()
    {
        string dbUri = "URI=file:alchENTImist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
    }
    //------ LOGIN FUNC
    void Login()
    {
        string ingredientsQuery = "SELECT id_user, name FROM users";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_user.Add(dataReader.GetInt32(0));
            name_user.Add(dataReader.GetString(1));
        }
    }
    public List<int> GetLoginIdList()
    {
        return id_user;
    }
    public List<string> GetLoginNameList()
    {
        return name_user;
    }

    //------ INGREDIENTS FUNC
    public List<int> GetIngredientIDList()
    {
        int id_ingredient = 0;
        List<int> ids_ingredients = new List<int>();

        string ingredientsQuery = "SELECT * FROM ingredients";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_ingredient = dataReader.GetInt32(0);
            ids_ingredients.Add(id_ingredient);
        }
        return ids_ingredients;
    }
    public string GetNameIngredient(int id_ingredient)
    {
        string name_ingredient = "name";

        string ingredientsQuery = "SELECT ingredient FROM ingredients WHERE id_ingredient = " + id_ingredient.ToString();
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            name_ingredient = dataReader.GetString(0);
        }

        return name_ingredient;
    }

    //------ POTIONS FUNC
    public List<int> GetPotionsIDList()
    {
        int id_potion = 0;
        List<int> ids_id_potions = new List<int>();

        string ingredientsQuery = "SELECT * FROM potions";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_potion = dataReader.GetInt32(0);
            ids_id_potions.Add(id_potion);
        }
        return ids_id_potions;
    }
    public string GetNamePotion(int id_potion)
    {
        string name_ingredient = "name";

        string ingredientsQuery = "SELECT potions FROM potions WHERE id_potion = " + id_potion.ToString();
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            name_ingredient = dataReader.GetString(0);
        }

        return name_ingredient;
    }
    //------ CHECK RECIPES
    public int CheckIdPotionFromIngredientDropped(int id_ingredient)
    {
        int id_potion = 0;

        string ingredientsQuery = "SELECT id_potion FROM potion_ingredients WHERE id_ingredient = " + id_ingredient;
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_potion = dataReader.GetInt32(0);
        }

        return id_potion;
    }
}