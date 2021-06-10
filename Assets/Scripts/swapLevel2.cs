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
        if (dm.curretChars.Contains('�') && dm.curretChars.Contains('�') && dm.curretChars.Contains('�'))
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
}
