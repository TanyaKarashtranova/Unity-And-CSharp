using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] GameObject loaderUI;
    [SerializeField] RectTransform loadingImageRectTransform;
    [SerializeField] RectTransform scrollRect;
    private Vector2 loaderMaxAnchor;
    private Vector2 scrollMinAnchor;

    private void Start()
    {
        scrollMinAnchor = scrollRect.anchorMin;
        loaderMaxAnchor = loadingImageRectTransform.anchorMax;
    }

    public void ShowLoadingAnimation()
    {
        scrollRect.anchorMin = new Vector2(scrollMinAnchor.x,loaderMaxAnchor.y);
        loaderUI.SetActive(true);
    }

    public void HideLoadingAnimation()
    {
        scrollRect.anchorMin = scrollMinAnchor;
        loaderUI.SetActive(false);
    }
}
