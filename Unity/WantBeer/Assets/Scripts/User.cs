using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    public string Username;
    public string Password;

    public User(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
}
