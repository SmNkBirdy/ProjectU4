using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UserManager : MonoBehaviour
{
    public InputField login;
    public InputField register;
    public DataManager dm;

    private void Start()
    {

    }

    public void loginBut()
    {
        UserData udata = SaveSystem.loadUser(login.text, register.text);
        if (udata != null)
        {
            dm.loadData(udata.id);
            SceneManager.LoadScene(dm.level);
        }
    }

    public void registerBut()
    {
        SaveSystem.addUser(login.text, register.text);
        UserData udata = SaveSystem.loadUser(login.text, register.text);
        dm.id = udata.id;
        dm.level = 2;
        dm.saveData();
        SceneManager.LoadScene(dm.level);
    }

    public void toRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void toLogin()
    {
        SceneManager.LoadScene(0);
    }
}
