using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private SceneController sceneController;

    private void Start()
    {
        sceneController = SceneController.GetInstance();
    }
    public void OnLoginButtonClick()
    {
        sceneController.LoadLoginScene();
    }

    public void OnRegistrationButtonClick()
    {
        sceneController.LoadRegistrationScene();
    }
}
