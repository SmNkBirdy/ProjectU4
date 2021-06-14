using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charManager : MonoBehaviour
{
    public GameObject middle;
    public List<GameObject> chars;
    public List<GameObject> rightChars;
    public int currentChar;
    public bool charSelected;
    private Vector3 _cachePos;
    private float lowPos;
    private float highPos;
    private float midPos;
    private bool winState = false;
    private bool winCheck = false;
    private GameObject[] blocks;
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        blocks = GameObject.FindGameObjectsWithTag("Puzzle");
        foreach (var item in blocks)
        {
            item.GetComponent<pazzleElement>().enabled = false;
            item.transform.position += (item.transform.position - new Vector3(middle.transform.position.x, middle.transform.position.y, item.transform.position.z)).normalized * 60;
            item.GetComponent<pazzleElement>().enabled = true;
        }
        currentChar = 1;
        lowPos = chars[currentChar].transform.position.y;
        midPos = lowPos + .2f;
        highPos = midPos + .8f;
        chars[currentChar].transform.position =  new Vector3(chars[currentChar].transform.position.x, midPos, chars[currentChar].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (getEquality(chars, rightChars))
        {
            winState = true;
        }
        if (winState)
        {
            winFunction();
        }
        else
        {
            if (Input.GetKeyDown("w"))
            {
                if (charSelected)
                {

                }
                else
                {
                    chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, highPos, chars[currentChar].transform.position.z);
                    charSelected = true;
                }
            }
            else if (Input.GetKeyDown("a"))
            {
                if (currentChar - 1 >= 0)
                {
                    if (charSelected)
                    {
                        _cachePos = chars[currentChar].transform.position;
                        chars[currentChar].transform.position = new Vector3(chars[currentChar - 1].transform.position.x, highPos, chars[currentChar - 1].transform.position.z); ;
                        chars[currentChar - 1].transform.position = new Vector3(_cachePos.x, lowPos, _cachePos.z);
                        chars.Reverse(currentChar - 1, 2);
                        currentChar -= 1;
                    }
                    else
                    {
                        chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, lowPos, chars[currentChar].transform.position.z);
                        currentChar -= 1;
                        chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, midPos, chars[currentChar].transform.position.z);
                    }
                }
            }
            else if (Input.GetKeyDown("s"))
            {
                if (charSelected)
                {
                    chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, midPos, chars[currentChar].transform.position.z);
                    charSelected = false;
                }
                else
                {

                }
            }
            else if (Input.GetKeyDown("d"))
            {
                if (currentChar + 1 < chars.Count)
                {
                    if (charSelected)
                    {
                        _cachePos = chars[currentChar].transform.position;
                        chars[currentChar].transform.position = new Vector3(chars[currentChar + 1].transform.position.x, highPos, chars[currentChar + 1].transform.position.z); ;
                        chars[currentChar + 1].transform.position = new Vector3(_cachePos.x, lowPos, _cachePos.z);
                        chars.Reverse(currentChar, 2);
                        currentChar += 1;
                    }
                    else
                    {
                        chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, lowPos, chars[currentChar].transform.position.z);
                        currentChar += 1;
                        chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, midPos, chars[currentChar].transform.position.z);
                    }
                }
            }
        }
    }

    private bool getEquality(List<GameObject> listA, List<GameObject> listB)
    {
        if (listA.Count == listB.Count)
        {
            for (int i = 0; i < listA.Count; i++)
            {
                if (listA[i] != listB[i])
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    private void winFunction()
    {
        if (!winCheck)
        {
            chars[currentChar].transform.position = new Vector3(chars[currentChar].transform.position.x, lowPos, chars[currentChar].transform.position.z);
            foreach (var item in blocks)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().velocity = (item.transform.position - middle.transform.position).normalized * 5;
                item.GetComponent<pazzleElement>().enabled = false;
            }
            gameObject.GetComponent<DataManager>().score += 4;
            gameObject.GetComponent<DataManager>().saveData();
            winCheck = true;
            winText.SetActive(true);    
        }
    }
}


