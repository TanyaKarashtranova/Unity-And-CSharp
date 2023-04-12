using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSession : MonoBehaviour
{
    private User currentUser;
    private Beer currentBeer;
    private const string UserSession = "currentUser";
    private static ApplicationSession instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static ApplicationSession GetInstance()
    {
        return instance;
    }

    public void SetUserSession(User user)
    {
        currentUser = user;
        PlayerPrefs.SetString(UserSession, JsonUtility.ToJson(currentUser));
    }

    public User GetCurrentUser()
    {
        return currentUser;
    }

    public void ClearUserSession()
    {
        PlayerPrefs.DeleteKey(UserSession);
    }

    public bool DoesUserSessionExist()
    {
        return PlayerPrefs.HasKey(UserSession);
    }

    public void SetCurrentBeer(Beer beer)
    {
        currentBeer = beer;
    }

    public Beer GetCurrentBeer()
    {
        return currentBeer;
    }
}