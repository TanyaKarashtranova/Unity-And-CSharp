using TMPro;
using UnityEngine;
using Assets.Scripts;

public class UserInputController : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TMP_InputField confirmPasswordInputField;
    [SerializeField] private ErrorContoller errorController;
    [SerializeField] private UserRepositoryController userRepositoryController;
    private SceneController sceneController;
    private bool isValidUsername;
    private bool isValidPassword;
    private bool doPasswordsMatch;

    private void Start()
    {
        sceneController = SceneController.GetInstance();
    }

    public void OnRegisterClick()
    {
        ResetFlags();
        errorController.ResetErrors();
        string username = usernameInputField.text;
        string password = passwordInputField.text;
        string confirmPassword = confirmPasswordInputField.text;
        SetIsValidUsername(username);
        SetIsValidPassword(password);
        doPasswordsMatch = password.Equals(confirmPassword);
        if (isValidUsername && isValidPassword && doPasswordsMatch)
        {
            Register(username, password);
        }
        else
        {
            ShowErrors();
        }
    }

    public void OnLoginClick()
    {
        errorController.ResetLoginError();
        Login(usernameInputField.text, passwordInputField.text);
    }

    private void SetIsValidPassword(string password)
    {
        if ((password.Length > Utility.MinimumCharactersNumberForPassword) && DoesInputContainNumber(password)
            && DoesInputContainSpecialSymbol(password) && DoesInputContainUpperCase(password))
        {
            isValidPassword = true;
        }
        else
        {
            isValidPassword = false;
        }
    }

    private void SetIsValidUsername(string username)
    {
        if ((username.Length > Utility.MinimumCharactersNumberForUsername) && !DoesInputContainSpecialSymbol(username))
        {
            isValidUsername = true;
        }
        else
        {
            isValidUsername = false;
        }
    }

    private bool DoesInputContainNumber(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool DoesInputContainUpperCase(string input)
    {
        foreach (char c in input)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;
    }

    private bool DoesInputContainSpecialSymbol(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return true;
            }
        }
        return false;
    }

    private void Register(string username, string password)
    {
        User user = userRepositoryController.CreateAccount(username, password);
        if (user != null)
        {
            LoadHomeSceneForTheAuthenitcatedUser(user);
        }
        else
        {
            errorController.ShowUserAlreadyExistError();
        }
    }

    private void Login(string username, string password)
    {
        User user = userRepositoryController.GetAccount(username, password);
        if (user != null)
        {
            LoadHomeSceneForTheAuthenitcatedUser(user);
        }
        else
        {
            errorController.ShowLoginError();
        }
    }

    public void ShowErrors()
    {
        if (!isValidUsername)
        {
            errorController.ShowInvalidUsernameError();
        }
        if (!isValidPassword)
        {
            errorController.ShowPasswordError();
        }
        if (!doPasswordsMatch)
        {
            errorController.ShowConfirmPasswordError();
        }
    }

    public void ResetFlags()
    {
        isValidPassword = true;
        isValidUsername = true;
        doPasswordsMatch = true;
    }

    private void LoadHomeSceneForTheAuthenitcatedUser(User user)
    {
        ApplicationSession.GetInstance().SetUserSession(user);
        sceneController.LoadHomeScene();
    }

    public void OnGoBackButtonClick()
    {
        sceneController.LoadAuthenticatorScene();
    }
}