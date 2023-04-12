using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class FoodUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI content;

    public void DisplayBeer(Sprite sprite, string text)
    {
        image.sprite = sprite;
        content.text = text;
    }
}

