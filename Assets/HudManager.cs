using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text h;
    public Text s;
    public DataManager dm;
    public playerHealth ph;
    void Update()
    {
        s.text = "Score: " + dm.score.ToString();
        h.text = "Health:" + ph.Health;
    }
}
