using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using System.Collections.Generic;
using System;

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
    //------ REGISTER FUNC
    public void CreateUser(string userName)
    {

        string query = "INSERT INTO users (name, date, level) VALUES ('" + userName.ToString() + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "', 1)";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
    }

    public void CreateBankAccount(int userID)
    {

        string query = "INSERT INTO bank_accounts (banalce, id_user) VALUES (1000, " + userID.ToString() + ")";

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
    }
    //------ PLAYER STATS FUNC
    public string GetUserName(int userId)
    {
        OpenDatabase();

        string name = "";

        string query = "SELECT * FROM users WHERE id_user=" + userId.ToString();

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            name = dataReader.GetString(1);
        }

        return name;
    }
    public float GetPlayerBalance(int userId)
    {
        OpenDatabase();

        float balance = 0;

        string query = "SELECT * FROM bank_accounts WHERE id_user=" + userId.ToString();

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            balance = dataReader.GetFloat(1);
        }

        return balance;
    }

    public int GetPlayerLvl(int userId)
    {
        OpenDatabase();

        int lvl = 0;

        string query = "SELECT * FROM users WHERE id_user=" + userId.ToString();

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {
            lvl = dataReader.GetInt32(3);
        }

        return lvl;
    }
    public void SetPlayerBalance(int userId, float newBalance)
    {
        OpenDatabase();

        string query = "UPDATE bank_accounts SET banalce=" + newBalance.ToString() + " WHERE id_user=" + userId.ToString();

        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = query;

        IDataReader dataReader = cmd.ExecuteReader();
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