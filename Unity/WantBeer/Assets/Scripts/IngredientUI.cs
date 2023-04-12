using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private TextMeshProUGUI header;
    public string[] ingredientsHeader = { "Malt", "Hops", "Yeild" };

    public void DisplayBeer(Sprite sprite, string text,int i)
    {
        image.sprite = sprite;
        content.text = text;
        header.text = ingredientsHeader[i];
    }
}
