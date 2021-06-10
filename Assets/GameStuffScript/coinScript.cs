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
    public AudioSource auds;
    void Start()
    {
        auds = GameObject.Find("coinSound").GetComponent<AudioSource>();
        dm = GameObject.Find("GameManager").GetComponent<DataManager>();
        charObject.text = charText.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            auds.Play();
            dm.curretChars.Add(charText);
            dm.score += 1;
            gameObject.SetActive(false);
        }
    }
}
