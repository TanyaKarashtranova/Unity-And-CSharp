using UnityEngine;

public class ApplicationManager : MonoBehaviour
{

    public void OnExitButtonClick()
    {
        ApplicationSession.GetInstance().ClearUserSession();
        Application.Quit();
    }
}