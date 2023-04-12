using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;
using UnityEngine.UI;
using UnityEditor;

public class ErrorContoller : MonoBehaviour
{
    [SerializeField] private GameObject usernameRegistationError;
    [SerializeField] private GameObject passwordRegistationError;
    [SerializeField] private GameObject confirmPasswordRegistationError;
    [SerializeField] private GameObject loginError;
    [SerializeField] private Color standartColor;
    [SerializeField] private Color errorColor ;
    private string usernameInvalidErrorText = "Username must be at least " + Utility.MinimumCharactersNumberForUsername + " characters and cannot contain special symbols!";
    private string passwordErrorText = "Password must contain minimum " + Utility.MinimumCharactersNumberForPassword + " characters. At least one number, one uppercase letter and one special symbol!";
    private const string ConfirmPasswordErrorText = "Passwords do not match!";
    private const string LoginErrorText = "Login failed - Username or password did not match.";
    private const string UserAlreadyExistErrorText = "User with that username has already existed.";

    private void Start()
    {
        ShowRequirements(usernameRegistationError, usernameInvalidErrorText, standartColor);
        ShowRequirements(passwordRegistationError, passwordErrorText, standartColor);
    }

    private void ShowRequirements(GameObject gameObject, string text, Color newColor)
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<TextMeshProUGUI>().text = text;
            gameObject.GetComponent<TextMeshProUGUI>().color = newColor;
        }
    }

    public void ShowInvalidUsernameError()
    {
        ShowRequirements(usernameRegistationError, usernameInvalidErrorText, errorColor);
    }
        
    public void ShowPasswordError()
    {
        ShowRequirements(passwordRegistationError, passwordErrorText, errorColor);
    }

    public void ShowConfirmPasswordError()
    {
        ShowRequirements(confirmPasswordRegistationError, ConfirmPasswordErrorText, errorColor);
    }

    public void ShowUserAlreadyExistError()
    {
        ShowRequirements(usernameRegistationError, UserAlreadyExistErrorText, errorColor);
    }

    public void ShowLoginError()
    {
        ShowRequirements(loginError, LoginErrorText, errorColor);
    }

    public void ResetErrors()
    {
        ResetRequirement(usernameRegistationError, standartColor);
        ResetRequirement(passwordRegistationError, standartColor);
        confirmPasswordRegistationError.SetActive(false);
    }

    private void ResetRequirement(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<TextMeshProUGUI>().color = color;
    }

    public void ResetLoginError()
    {
        loginError.SetActive(false);
    }
}
