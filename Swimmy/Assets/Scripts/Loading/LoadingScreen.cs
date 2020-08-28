using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject loadingText1;
    public GameObject loadingText2;

    void Start()
    {
        //While Lobby is loading
        sphere1.SetActive(true);
        sphere2.SetActive(true);
        loadingText1.SetActive(true);
        loadingText2.SetActive(false);
    }

    void Update()
    {
        //If any scene has finished loading
        if (SceneLoader.Instance.isLoading == false)
        {
            sphere1.SetActive(false);
            sphere2.SetActive(false);
            loadingText1.SetActive(false);
            loadingText2.SetActive(false);
        }
        else if (SceneLoader.Instance.gameIsLoading)
        {
            sphere1.SetActive(true);
            sphere2.SetActive(true);
            loadingText1.SetActive(false);
            loadingText2.SetActive(true);
        }
    }
}
