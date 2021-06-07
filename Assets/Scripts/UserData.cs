using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public int id;
    public string login;
    public string password;

    public UserData(int Ourid, string Ourlogin, string Ourpassword)
    {
        id = Ourid;
        login = Ourlogin;
        password = Ourpassword;
    }
}
