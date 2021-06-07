using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinScript : MonoBehaviour
{
    public DataManager dm;
    public char charText;
    public TextMeshProUGUI charObject;
    void Start()
    {
        dm = GameObject.Find("GameManager").GetComponent<DataManager>();
        charObject.text = charText.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dm.curretChars.Add(charText);
            dm.score += 2;
            gameObject.SetActive(false);
        }
    }
}
