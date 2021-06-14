using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public int id;
    public string login;
    public string password;
    public int level;
    public int checkpoint;
    public int score;
    public List<char> allChars = new List<char> () 
    {
        'à',
        'á',
        'â',
        'ã',
        'ä',
        'å',
        '¸',
        'æ',
        'ç',
        'è',
        'é',
        'ê',
        'ë',
        'ì',
        'í',
        'î',
        'ï',
        'ð',
        'ñ',
        'ò',
        'ó',
        'ô',
        'õ',
        'ö',
        '÷',
        'ø',
        'ù',
        'ú',
        'û',
        'ü',
        'ý',
        'þ',
        'ÿ'
    };

    public List<char> curretChars;

    public void ResetData()
    {
        PlayerPrefs.SetInt("id", 0);
    }

    public DataManager(int cscore, string cchars, int clevel, int ccheckpoint)
    {
        score = cscore;
        for (int i = 0; i < cchars.Length; i++)
        {
            if (curretChars == null)
            {
                curretChars = new List<char>();
            }
            curretChars.Add(cchars[i]);
        }
        level = clevel;
        checkpoint = ccheckpoint;
    }

    private void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("id", 0);
        }

        if (PlayerPrefs.GetInt("id") != 0)
        {
            id = PlayerPrefs.GetInt("id");
            loadData(id);
            level = SceneManager.GetActiveScene().buildIndex;
            saveData();
        }
        else
        {
            SaveSystem.createDB();
        }

        if (curretChars == null) 
        {
            curretChars = new List<char>();
        }
    }

    public void onNextLevel()
    {
        saveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void saveData()
    {
        SaveSystem.SaveData(this);
    }

    public void loadData(int mId)
    {
        GameData data = SaveSystem.LoadData(mId);
        if (data == null)
        {
            saveData();
        }
        else
        {
            score = data.score;
            checkpoint = data.checkpoint;
            curretChars = data.currentChars;
            level = data.level;
            id = mId;
            PlayerPrefs.SetInt("id", mId);
        }
    }
}
