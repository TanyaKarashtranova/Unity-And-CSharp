using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchResultManager : MonoBehaviour
{
    [SerializeField] private GameObject message;
    private const string NoResultsText = "No results.";

    public void  ShowNoResultMessage()
    {
        message.SetActive(true);
        message.GetComponentInChildren<TextMeshProUGUI>().text = NoResultsText;
    }
       
    public void HideMessage()
    {
        message.SetActive(false);
    }   
}
