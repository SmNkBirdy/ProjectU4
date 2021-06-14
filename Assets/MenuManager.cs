using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject menu;
    public GameObject hat1;
    public GameObject hatIndicator1;
    public GameObject hat2;
    public GameObject hatIndicator2;
    public GameObject hat3;
    public GameObject hatIndicator3;
    public GameObject hat4;
    public GameObject hatIndicator4;
    public HudManager heMan;
    public GameObject buddy1;
    public GameObject buddy2;
    public GameObject buddy3;
    public GameObject buddy4;
    public DataManager dm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
        }
        showHats(heMan.level);
        activeHat(dm.checkpoint);
    }

    public void quitAcc()
    {
        SceneManager.LoadScene(0);
    }

    public void menuSwitch()
    {
        menu.SetActive(!menu.activeSelf);
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void clearHats()
    {
        Debug.Log("kek");
        dm.checkpoint = 0;
        hat1.SetActive(false);
        hat2.SetActive(false);
        hat3.SetActive(false);
        hat4.SetActive(false);
        hatIndicator1.SetActive(false);
        hatIndicator2.SetActive(false);
        hatIndicator3.SetActive(false);
        hatIndicator4.SetActive(false);
    }

    public void activateHat1()
    {
        Debug.Log("kek");
        dm.checkpoint = 1;
        hat1.SetActive(true);
        hat2.SetActive(false);
        hat3.SetActive(false);
        hat4.SetActive(false);
        hatIndicator1.SetActive(true);
        hatIndicator2.SetActive(false);
        hatIndicator3.SetActive(false);
        hatIndicator4.SetActive(false);
    }

    public void activateHat2()
    {
        Debug.Log("kek");
        dm.checkpoint = 2;
        hat1.SetActive(false);
        hat2.SetActive(true);
        hat3.SetActive(false);
        hat4.SetActive(false);
        hatIndicator1.SetActive(false);
        hatIndicator2.SetActive(true);
        hatIndicator3.SetActive(false);
        hatIndicator4.SetActive(false);
    }

    public void activateHat3()
    {
        Debug.Log("kek");
        dm.checkpoint = 3;
        hat1.SetActive(false);
        hat2.SetActive(false);
        hat3.SetActive(true);
        hat4.SetActive(false);
        hatIndicator1.SetActive(false);
        hatIndicator2.SetActive(false);
        hatIndicator3.SetActive(true);
        hatIndicator4.SetActive(false);
    }

    public void activateHat4()
    {
        Debug.Log("kek");
        dm.checkpoint = 4;
        hat1.SetActive(false);
        hat2.SetActive(false);
        hat3.SetActive(false);
        hat4.SetActive(true);
        hatIndicator1.SetActive(false);
        hatIndicator2.SetActive(false);
        hatIndicator3.SetActive(false);
        hatIndicator4.SetActive(true);
    }

    public void showHats(int i)
    {
        if (i == 1)
        {
            buddy1.SetActive(true);
            buddy2.SetActive(false);
            buddy3.SetActive(false);
            buddy4.SetActive(false);
        }
        else if (i == 2)
        {
            buddy1.SetActive(true);
            buddy2.SetActive(true);
            buddy3.SetActive(false);
            buddy4.SetActive(false);
        }
        else if (i == 3)
        {
            buddy1.SetActive(true);
            buddy2.SetActive(true);
            buddy3.SetActive(true);
            buddy4.SetActive(false);
        }
        else if (i >= 4)
        {
            buddy1.SetActive(true);
            buddy2.SetActive(true);
            buddy3.SetActive(true);
            buddy4.SetActive(true);
        }
        else if (i == 0)
        {
            buddy1.SetActive(false);
            buddy2.SetActive(false);
            buddy3.SetActive(false);
            buddy4.SetActive(false);
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(false);
            hat4.SetActive(false);
            hatIndicator1.SetActive(false);
            hatIndicator2.SetActive(false);
            hatIndicator3.SetActive(false);
            hatIndicator4.SetActive(false);
        }
    }

    public void activeHat(int i)
    {
        if (i == 1)
        {
            hat1.SetActive(true);
            hat2.SetActive(false);
            hat3.SetActive(false);
            hat4.SetActive(false);
            hatIndicator1.SetActive(true);
            hatIndicator2.SetActive(false);
            hatIndicator3.SetActive(false);
            hatIndicator4.SetActive(false);
        }
        else if (i == 2)
        {
            hat1.SetActive(false);
            hat2.SetActive(true);
            hat3.SetActive(false);
            hat4.SetActive(false);
            hatIndicator1.SetActive(false);
            hatIndicator2.SetActive(true);
            hatIndicator3.SetActive(false);
            hatIndicator4.SetActive(false);
        }
        else if (i == 3)
        {
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(true);
            hat4.SetActive(false);
            hatIndicator1.SetActive(false);
            hatIndicator2.SetActive(false);
            hatIndicator3.SetActive(true);
            hatIndicator4.SetActive(false);
        }
        else if (i == 4)
        {
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(false);
            hat4.SetActive(true);
            hatIndicator1.SetActive(false);
            hatIndicator2.SetActive(false);
            hatIndicator3.SetActive(false);
            hatIndicator4.SetActive(true);
        }
        else
        {
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(false);
            hat4.SetActive(false);
            hatIndicator1.SetActive(false);
            hatIndicator2.SetActive(false);
            hatIndicator3.SetActive(false);
            hatIndicator4.SetActive(false);
        }
    }
}
