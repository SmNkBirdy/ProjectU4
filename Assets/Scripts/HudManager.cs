using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public List<int> intsOfLevels;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public Slider exp;
    public int score;
    public int level;
    public DataManager dm;
    public playerHealth ph;
    public bool healthActive;

    void Update()
    {
        score = dm.score;
        for (int i = 0; i < intsOfLevels.Count; i++)
        {
            if (score >= intsOfLevels[i])
            {
                if (i + 1 < intsOfLevels.Count)
                {
                    score -= intsOfLevels[i];
                    level = i + 1;
                }
            }
        }
        exp.value = (float)score / (float)intsOfLevels[level];
        if (healthActive)
        {
            if (ph.Health > 2)
            {
                hp1.SetActive(true);
                hp2.SetActive(true);
                hp3.SetActive(true);
            }
            else if (ph.Health > 1)
            {
                hp1.SetActive(true);
                hp2.SetActive(true);
                hp3.SetActive(false);
            }
            else if (ph.Health > 0)
            {
                hp1.SetActive(true);
                hp2.SetActive(false);
                hp3.SetActive(false);
            }
            else
            {
                hp1.SetActive(false);
                hp2.SetActive(false);
                hp3.SetActive(false);
            }
        }
        else
        {
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(false);
        }
    }
}
