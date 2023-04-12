using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;

public class BaseInformationUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI content;
    private string[] BaseInformationHeaders = { "First Brewed: ", "Alcohol by Volume: ", "Bitterness: ", "EBC Color: " };
    /*private static int Counter = 0;*/

    /*public void DisplayBeer(string text)
    {
        if (Counter == BaseInformationHeaders.Length)
        {
            Counter = 0;
        }
        content.text = BaseInformationHeaders[Counter++] + text;
    }*/
    public void DisplayBeer(Sprite sprite, string text, int i)
    {
        image.sprite = sprite;
        content.text = text + BaseInformationHeaders[i];
    }
}
