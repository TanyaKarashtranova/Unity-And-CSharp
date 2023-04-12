using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailsSceneManager : BeerItemUI
{
    [Header("Base Information")]
    /*    [SerializeField] private BaseInformationUI firstBrewed;
        [SerializeField] private BaseInformationUI alcoholByVolume;
        [SerializeField] private BaseInformationUI bitterness;
        [SerializeField] private BaseInformationUI EBCColor;*/
    [SerializeField] private BaseInformationUI baseInformationUI;
    [SerializeField] private List<Sprite> informationImages;
    [SerializeField] private Transform ScrollViewBaseInformation;
    private int counter = 0;

    [Header("Ingredients")]
    [SerializeField] private IngredientUI ingredientUILeft;
    [SerializeField] private IngredientUI ingredientUIRight;
    [SerializeField] private List<Sprite> IngredientsImages;
    [SerializeField] private Transform ScrollViewIngredients;

    [Header("Food")]
    [SerializeField] private FoodUI foodUILeft;
    [SerializeField] private FoodUI foodUIRight;
    [SerializeField] private List<Sprite> foodImages;
    [SerializeField] private Transform ScrollViewBaseFood;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI brewersTips;
    [SerializeField] private TextMeshProUGUI contributedBy;

    private Beer beer;

    private void Start()
    {
        beer = ApplicationSession.GetInstance().GetCurrentBeer();
        DisplayBeerDetails();
    }

    private void InstatiateBaseInformationUI(int counter, string information)
    {
        BaseInformationUI baseInfo = Instantiate(baseInformationUI, ScrollViewBaseInformation);
        baseInfo.DisplayBeer(informationImages[counter], information, counter);
    }

    private void DisplayBaseInformation()
    {
        if (beer.FirstBrewed != null)
        {
            InstatiateBaseInformationUI(counter, beer.FirstBrewed);
        }
        counter++;
        if (beer.Abv != 0)
        {
            InstatiateBaseInformationUI(counter, beer.Abv.ToString());
        }
        counter++;
        if (beer.Ibu != 0)
        {
            InstatiateBaseInformationUI(counter, beer.Ibu.ToString());
        }
        counter++;
        if (beer.Ebc != 0)
        {
            InstatiateBaseInformationUI(counter, beer.Ebc.ToString());
        }
        counter = 0;
    }

    private void DisplayBeerDetails()
    {
        StartCoroutine(BeerRepositoryController.GetInstance().GetImageFromURL(beer.Image, DisplayImage));
        DisplayBeer(beer);
        description.text = beer.Description;

        /*firstBrewed.DisplayBeer(beer.FirstBrewed);
        alcoholByVolume.DisplayBeer(beer.Abv.ToString());
        bitterness.DisplayBeer(beer.Ibu.ToString());
        EBCColor.DisplayBeer(beer.Ebc.ToString());*/
        /*        DisplayIngredients(beer.IngredientsList);
                DisplayFood(beer.Foods);*/
        brewersTips.text = "Brewers Tips: " + beer.BrewersTips;
        contributedBy.text ="Contributed By: " +  beer.ContributedBy;
        SceneController.GetInstance().StopTransitionAnimation();
    }

    /*private void DisplayIngredients(Ingredients ingredientsList)
    {
        if (ingredientsList != null)
        {
            ingredientsHeader.SetActive(true);
            string info = "";
            foreach (Malt malt in ingredientsList.Malt)
            {
                info += $"{malt.Name} - {malt.Amount.Value} {malt.Amount.Unit}\n";
            }
            DisplayIngredient(0, info);
            info = "";
            foreach (Hops hop in ingredientsList.Hops)
            {
                info += $"{hop.Name} - {hop.Amount.Value} {hop.Amount.Unit}\n";
            }
            DisplayIngredient(1, info);
            DisplayIngredient(2, ingredientsList.Yeast);
        }
    }

    private void DisplayIngredient(int i, string info)
    {
        ingredients[i].SetActive(true);
        int childCount = ingredients[1].transform.childCount;
        ingredients[i].transform.GetChild(childCount - 1).GetComponent<TextMeshProUGUI>().text = info;
    }

    private void DisplayFood(List<string> beerFood)
    {
        if (beerFood.Count > 0)
        {
            foodHeader.SetActive(true);
            for (int i = 0; i < beerFood.Count; i++)
            {
                foods[i].SetActive(true);
                foods[i].GetComponentInChildren<TextMeshProUGUI>().text = beerFood[i];
            }
        }
    }*/

    public void GoBackButtonClick()
    {
        SceneController.GetInstance().LoadHomeScene();
    }
}
