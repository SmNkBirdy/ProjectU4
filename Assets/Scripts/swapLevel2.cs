using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class swapLevel2 : MonoBehaviour
{
    public DataManager dm;

    private void Start()
    {
        dm = GameObject.Find("GameManager").GetComponent<DataManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        dm.saveData();
        if (dm.curretChars.Contains('ê') && dm.curretChars.Contains('î') && dm.curretChars.Contains('ò'))
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
}
