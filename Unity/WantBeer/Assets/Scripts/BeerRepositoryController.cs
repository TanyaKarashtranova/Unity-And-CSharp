using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BeerRepositoryController : MonoBehaviour
{
    private readonly string baseBeerURL = "https://api.punkapi.com/v2/";
    private static BeerRepositoryController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static BeerRepositoryController GetInstance()
    {
        return instance;
    }

    public IEnumerator GetBeersFromPage(int page, string filter, Action<List<Beer>> callback = null)
    {
        string beerURLPage = baseBeerURL + "beers?page=" + page + filter;
        UnityWebRequest beersAtPageRequest = UnityWebRequest.Get(beerURLPage);
        yield return beersAtPageRequest.SendWebRequest();
        switch (beersAtPageRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.ProtocolError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(beersAtPageRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                List<Beer> beers = JsonConvert.DeserializeObject<List<Beer>>(beersAtPageRequest.downloadHandler.text);
                callback(beers);
                break;
        }
    }

    public IEnumerator GetImageFromURL(string url, Action<Texture2D> callback)
    {
        UnityWebRequest imageRequest = UnityWebRequestTexture.GetTexture(url);
        yield return imageRequest.SendWebRequest();
        switch (imageRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.ProtocolError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(imageRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Texture2D texture = ((DownloadHandlerTexture)imageRequest.downloadHandler).texture;
                callback(texture);
                break;
        }
    }
}