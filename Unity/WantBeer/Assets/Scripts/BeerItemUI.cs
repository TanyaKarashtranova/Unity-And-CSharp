using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeerItemUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI objectName;
    [SerializeField] private TextMeshProUGUI tagline;
    private int id;
    private Beer beer;

    public void DisplayImage(Texture2D texture)
    {
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void DisplayBeer(Beer beer)
    {
        this.beer = beer;
        objectName.text = beer.Name;
        tagline.text = beer.Tagline;
        id = beer.Id;
    }

    public void OnBeerItemClick()
    {
        SceneController.GetInstance().LoadDetailsScene(beer);
    }
}