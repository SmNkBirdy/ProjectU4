using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public List<char> currentChars;
    public int id;
    public int level;
    public int checkpoint;

    public GameData(DataManager data)
    {
        score = data.score;
        currentChars = data.curretChars;
        id = data.id;
        level = data.level;
        checkpoint = data.checkpoint;
    }
}
