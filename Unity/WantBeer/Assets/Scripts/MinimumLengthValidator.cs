using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinimumLengthValidator : MonoBehaviour
{
    [SerializeField] private Button searchButton;
    [SerializeField] private GameObject searchMessage;
    private string searchInputMessageText = "Please, enter at least " + minimumCharachters +" characters.";
    private const int minimumCharachters = 3;
    
    public void OnChangeInput(string input)
    {
        if (input.Length < minimumCharachters)
        {
            searchMessage.SetActive(true);
            searchMessage.GetComponent<TextMeshProUGUI>().text = searchInputMessageText;
            searchButton.interactable = false;
        }
        else 
        {
            searchButton.interactable = true;
            searchMessage.SetActive(false);
        }
    }
}
