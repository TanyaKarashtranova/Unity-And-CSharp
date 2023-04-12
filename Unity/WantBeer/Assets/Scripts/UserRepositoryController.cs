using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRepositoryController : MonoBehaviour
{   
    public User CreateAccount(string username, string password)
    {
        if (!DoesAccountAlreadyExist(username))
        {
            User user = new User(username, password);
            string account = JsonUtility.ToJson(user);
            PlayerPrefs.SetString("user:" + username, account);
            return user;
        }
        return null;
    }

    public User GetAccount(string username, string password)
    {
        if (DoesAccountAlreadyExist(username))
        {
            string userAccount = PlayerPrefs.GetString("user:" + username);
            User user = JsonUtility.FromJson<User>(userAccount);
            if (user.Password.Equals(password))
            {
                return user;
            }
        }
        return null;
    }
    
    public bool DoesAccountAlreadyExist(string username)
    {
        return PlayerPrefs.HasKey("user:" + username);
    }
}
