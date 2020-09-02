using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public UnityEvent OnLoadBegin = new UnityEvent();
    public UnityEvent OnLoadEnd = new UnityEvent();
    public ScreenFader screenFader = null;

    //Bools used in LoadingScreen.cs and SwitchLocomotion.cs
    public bool isLoading = false;
    public bool gameIsLoading = false;
    public bool lobbyIsLoading = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += SetActiveScene;

        //Start in the Lobby scene
        LoadNewScene("Lobby");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetActiveScene;
    }

    public void LoadNewScene(string sceneName)
    {
        if (sceneName == "Lobby")
        {
            lobbyIsLoading = true;
        }
        else if (sceneName == "GameScene")
        {
            gameIsLoading = true;
        }

        if (!isLoading)
            StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        isLoading = true;

        OnLoadBegin.Invoke();
        yield return StartCoroutine(UnloadCurrent());

        yield return StartCoroutine(LoadNew(sceneName));
        OnLoadEnd.Invoke();

        isLoading = false;
    }

    private IEnumerator UnloadCurrent()
    {
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        while (!unloadOperation.isDone)
            yield return null;
    }

    private IEnumerator LoadNew(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!loadOperation.isDone)
            yield return null;
    }

    private void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}

