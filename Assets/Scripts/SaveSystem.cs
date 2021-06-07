using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public static class SaveSystem
{
    private static string dbName = "URI=file:GameData.db";
    //private static string dbName = Application.persistentDataPath + "/gameData.db";

    public static void SaveData (DataManager dataManager)
    {
        GameData data = new GameData(dataManager);

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                bool check = false;
                command.CommandText = "SELECT * FROM saves;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(1) == data.id)
                        {
                            check = true;
                        }
                    }
                }
                string cchars = "";
                if (data.currentChars != null)
                {
                    foreach (var item in data.currentChars)
                    {
                        cchars += item;
                    }
                }

                if (check)
                {
                    command.CommandText = "UPDATE saves SET score = " + data.score + ", chars = '" + cchars + "', level = " + data.level + ", checkpoint = " + data.checkpoint + " WHERE _id = " + data.id + ";";
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText = "INSERT INTO saves (user_id, score, chars, level, checkpoint) VALUES ('" + data.id + "','" + data.score + "','" + cchars + "','" + data.level + "','" + data.checkpoint + "');";
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        /*using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //command.CommandText = "UPDATE saves SET score = "+ data.score + ", chars = '" + data.currentChars.ToString() + "', level = " + data.level + ", checkpoint = " + data.checkpoint + " WHERE id = " + data.id + ";";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }*

        /*BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cantTouchThis.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(dataManager);

        formatter.Serialize(stream, data);
        stream.Close();*/
    }

    public static GameData LoadData(int id)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM saves;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(1) == id)
                        {
                            GameData data = new GameData(new DataManager(reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5)));
                            return data;
                        }
                    }
                }
            }
            connection.Close();
        }

        /*string path = Application.persistentDataPath + "/cantTouchThis.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found");*/
        return null;
        //}
    }

    public static void createDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS users (_id INTEGER PRIMARY KEY, login VARCHAR(20) UNIQUE, password VARCHAR(30));";
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE IF NOT EXISTS saves (_id INTEGER PRIMARY KEY, user_id INT, score INTEGER, chars VARCHAR(33), level INTEGER, checkpoint INTEGER);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public static void addUser(string login, string password)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO users (login, password) VALUES ('"+ login + "','"+ password + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public static UserData loadUser(string login, string password)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM users;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == login && reader.GetString(2) == password)
                        {
                            UserData data = new UserData(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            PlayerPrefs.SetInt("id", data.id);
                            return data;
                        }
                    }
                }
            }
            connection.Close();
        }
        return null;
    }
}

