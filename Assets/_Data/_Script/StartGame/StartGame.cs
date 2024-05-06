using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Button btnPlaygame;
    [SerializeField] Button btnExitGame;
    [SerializeField] protected GameObject loadingInterface;
    [SerializeField] protected Image loadingProgresBar;
    [SerializeField] List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    private void Awake()
    {
        GetComponenButtonPlayGame();
        GetComponenButtonExitGame();
    }
    private void Start()
    {
        btnPlaygame.onClick.AddListener(() =>
        {
            StartLoadGame();
        });
        btnExitGame.onClick.AddListener(() =>
        {
            ExitGame();
        });

    }

    void GetComponenButtonPlayGame()
    {
        if (btnPlaygame != null) return;
        btnPlaygame = GetComponent<Button>();
        if (btnPlaygame == null) Debug.LogWarning("btnPlayGame of Scrpit StartGame Null");
    }
    void GetComponenButtonExitGame()
    {
        if (btnExitGame != null) return;
        btnExitGame = GetComponent<Button>();
        if (btnExitGame == null) Debug.LogWarning("btnExitGame of Scrpit StartGame Null");
    }
    public void StartLoadGame()
    {
        HideMenu(); // hide menu
        ShowingScenes();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("_Data/Scenes/main"));

        // scenesToLoad.Add(SceneManager.LoadSceneAsync("_Data/Scenes/Round1", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }

 
     
    private void ShowingScenes()
    {
        loadingInterface.SetActive(true);
    }

    private void HideMenu()
    {
       // btnPlaygame.SetActive(false);
        btnPlaygame.gameObject.SetActive(false);

    }

    private IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgresBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
    }
}
