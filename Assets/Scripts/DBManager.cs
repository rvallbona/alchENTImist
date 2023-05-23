using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using System.Collections.Generic;
public class DBManager : MonoBehaviour
{
    #region Variables
    [Header("DB")]
    IDbConnection dbConnection;

    [Header("Login")]
    [HideInInspector] public List<int> id_user = new List<int>();
    [HideInInspector] public List<string> name_user = new List<string>();

    [Header("Ingredients")]
    [HideInInspector] public List<int> id_ingredients = new List<int>();
    [HideInInspector] public List<string> name_ingredients = new List<string>();

    [Header("Potions")]
    [HideInInspector] public List<int> id_potions = new List<int>();
    [HideInInspector] public List<string> name_potions = new List<string>();
    [HideInInspector] public int id_potion_created;
    public GameObject ListaPociones;

    [Header("Recipies")]
    [HideInInspector] public List<int> id_potion_ingredient = new List<int>(), id_potion = new List<int>(), id_ingredient = new List<int>();
    [SerializeField] Potions scriptPotions;
    #endregion
    private void Awake()
    {
        #region Functions
        OpenDatabase();
        Login();
        IngredientList();
        PotionsList();
        Recipies();
        #endregion
    }
    #region DB
    private void OpenDatabase()
    {
        string dbUri = "URI=file:alchENTImist.db";
        dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();
    }
    #endregion
    #region Login
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
    #endregion
    #region GetLoginFunctions
    public List<int> GetLoginIdList()
    {
        return id_user;
    }
    public List<string> GetLoginNameList()
    {
        return name_user;
    }
    #endregion
    #region Ingredients
    void IngredientList()
    {
        string ingredientsQuery = "SELECT* FROM ingredients";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_ingredients.Add(dataReader.GetInt32(0));
            name_ingredients.Add(dataReader.GetString(1));
        }
    }
    #endregion
    #region GetIngredientsFuncions
    public List<int> GetIngredientsIdList()
    {
        return id_ingredients;
    }
    public List<string> GetIngredientsNameList()
    {
        return name_ingredients;
    }
    #endregion
    #region Potions
    void PotionsList()
    {
        string ingredientsQuery = "SELECT* FROM potions";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_potions.Add(dataReader.GetInt32(0));
            name_potions.Add(dataReader.GetString(1));
        }
    }
    #endregion
    #region GetPotionsFuncions
    public List<int> GetPotionIdList()
    {
        return id_potions;
    }
    public List<string> GetPotionsNameList()
    {
        return name_potions;
    }
    #endregion
    #region Recipies
    void Recipies()
    {
        string ingredientsQuery = "SELECT id_potion_ingredient, id_potion, id_ingredient FROM potion_ingredients";
        IDbCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = ingredientsQuery;
        IDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            id_potion_ingredient.Add(dataReader.GetInt32(0));
            id_potion.Add(dataReader.GetInt32(0));
            id_ingredient.Add(dataReader.GetInt32(0));
        }
    }
    #endregion
    #region GetRecipiesFuncions
    public List<int> GetRecipiesIdList()
    {
        return id_potion_ingredient;
    }
    public List<int> GetRecipiesIdPotionList()
    {
        return id_potions;
    }
    public List<string> GetRecipiesNameList()
    {
        return name_potions;
    }
    #endregion
    #region CheckRecipe
    //Comprovaciones Ingredientes Pociones
    public int CheckRecipe(List<string> ids_ingredients)
    {
        for (int i = 0; i < ids_ingredients.Count; i++)
        {
            string ingredientsQuery = "SELECT id_potion FROM potion_ingredients WHERE id_ingredient = ";
            ingredientsQuery = ingredientsQuery + ids_ingredients[i];
            IDbCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = ingredientsQuery;
            IDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                id_potion_created = dataReader.GetInt32(0);
            }
        }
        return id_potion_created;
    }
    #endregion
}