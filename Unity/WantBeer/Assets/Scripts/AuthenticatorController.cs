using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthenticatorController : MonoBehaviour
{
    private void Start()
    {
        if (ApplicationSession.GetInstance().DoesUserSessionExist())
        {
            SceneController.GetInstance().LoadHomeScene();
        }
    }
}
