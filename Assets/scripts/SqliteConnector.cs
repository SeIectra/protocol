using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SqliteConnector : MonoBehaviour
{
    [SerializeField] public int coinCount = 0;

    [SerializeField] public TMP_InputField inputField;

    [SerializeField] public Button addButton;

    [SerializeField] public Button deleteButton;

    [SerializeField] public TMP_Text userListText;

    private IDbConnection dbConnection;

    void Start()
    {
        dbConnection = CreateAndOpenDatabase();

        addButton.onClick.AddListener(AddUsername);
        deleteButton.onClick.AddListener(DeleteUsername);

        ReadUserList();

        Debug.Log("Sql Connector");
    }

    public void AddCoinCount(int coin)
    {
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "INSERT OR REPLACE INTO Underworld (id, coins) VALUES (0, " + coin + ");";
        dbCommandInsertValue.ExecuteNonQuery();
    }

    public void AddUsername()
    {
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
        dbCommandInsertValue.CommandText = "INSERT INTO Underworld (usernames) VALUES ('" + inputField.text + "');";
        dbCommandInsertValue.ExecuteNonQuery();

        ReadUserList();

        inputField.text = "";
    }

    public void DeleteUsername()
    {
        try{// Insert coins into the table.
        IDbConnection dbConnection = CreateAndOpenDatabase(); // 2
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand(); // 9
        dbCommandInsertValue.CommandText = "DELETE FROM Underworld WHERE id = "+ int.Parse(inputField.text) + ";"; // 10
        dbCommandInsertValue.ExecuteNonQuery(); // 11
        // Remember to always close the connection at the end.
        ReadUserList();
        dbConnection.Close(); // 12
        }
    catch{}
       
    }
    
   private void ReadUserList()
{
    IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
    dbCommandReadValues.CommandText = "SELECT * FROM Underworld";
    IDataReader dataReader = dbCommandReadValues.ExecuteReader();

    userListText.text = "";
    while (dataReader.Read())
    {
        string username = dataReader.GetString(1);
        userListText.text += dataReader.GetString(dataReader.GetOrdinal("usernames")) + "\n";
    }

    dataReader.Close();
}
    private IDbConnection CreateAndOpenDatabase()
    {
        string dbUri = "URI=file:UnderworldDatabase.db";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Underworld (id INTEGER PRIMARY KEY, usernames VARCHAR(255), coins INTEGER)";
        dbCommandCreateTable.ExecuteNonQuery();

        return dbConnection;
    }
}
