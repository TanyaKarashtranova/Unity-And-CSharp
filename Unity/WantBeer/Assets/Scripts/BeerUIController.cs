using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class BeerUIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchInputField;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private BeerItemUI beerItemUIPrefab;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private SearchResultManager searchResultManager;
    private BeerRepositoryController beerRepositoryController;
    private int currentPage;
    private int nextPage = 1;
    private double verticalScrollLowestPosition;
    private string searchParameter;
    private const float VerticalScrollHighestPosition = 1.0f;
    private bool isStarted = false;
    private Scroll scroll;

    private void Start()
    {
        scroll = scrollRect.GetComponent<Scroll>();
        beerRepositoryController = BeerRepositoryController.GetInstance();
        StartCoroutine(beerRepositoryController.GetBeersFromPage(nextPage, searchParameter, ShowBeers));
    }

    private void ShowBeers(List<Beer> listOfBeers)
    {
        if (listOfBeers.Count == 0)
        {
            if (nextPage == 1)
            {
                searchResultManager.ShowNoResultMessage();
            }
            else
            {
                scrollRect.onValueChanged.RemoveListener(OnChangePositionOfScroll);
            }
        }
        else
        {
            for (int i = 0; i < listOfBeers.Count; i++)
            {
                BeerItemUI newBeer = Instantiate(beerItemUIPrefab, scrollViewContent);
                StartCoroutine(beerRepositoryController.GetImageFromURL(listOfBeers[i].Image, newBeer.DisplayImage));
                newBeer.DisplayBeer(listOfBeers[i]);
            }
            verticalScrollLowestPosition = VerticalScrollHighestPosition / listOfBeers.Count;
            currentPage = nextPage;
        }
        if (isStarted)
        {
            scroll.HideLoadingAnimation();
        }
        else
        {     
            SceneController.GetInstance().StopTransitionAnimation();
            isStarted = true;
        }
        scrollRect.enabled = true;
    }

    public void OnChangePositionOfScroll(Vector2 position)
    {
        if (currentPage == nextPage && position.y <= verticalScrollLowestPosition)
        {
            scroll.ShowLoadingAnimation();
            scrollRect.enabled = false;
            nextPage++;
            StartCoroutine(beerRepositoryController.GetBeersFromPage(nextPage, searchParameter, ShowBeers));
        }
    }

    public void OnSearchClick()
    {
        scroll.ShowLoadingAnimation();
        searchResultManager.HideMessage();
        scrollRect.verticalNormalizedPosition = VerticalScrollHighestPosition;
        foreach (Transform child in scrollViewContent)
        {
            Destroy(child.gameObject);
        }
        nextPage = 1;
        searchParameter = "&beer_name=" + searchInputField.text.Replace(" ", "_");
        StartCoroutine(beerRepositoryController.GetBeersFromPage(nextPage, searchParameter, ShowBeers));
    }
}