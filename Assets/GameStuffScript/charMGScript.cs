using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class charMGScript : MonoBehaviour
{
    public TextMeshProUGUI charObject;
    public string charText;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        charObject.text = charText;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
