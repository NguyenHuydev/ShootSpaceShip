using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endGameUI;
    public bool gameEnded = false;
    private void Awake()
    {
        LoadEndGame();
    }
    void Start()
    {
        gameEnded = false;
        Invoke("LoadRound1", 2f);
    }

    private void Update()
    {
        EndGame();
    }

    private void LoadEndGame()
    {
        if (endGameUI != null) return;
        if (endGameUI == null) Debug.LogWarning("endGameUI of scrpit PlayScenesManager NULL ");
    }
    void LoadRound1()
    {
        SceneManager.LoadSceneAsync("_Data/Scenes/Round1", LoadSceneMode.Additive);
    }

    void EndGame()
    {
        if (gameEnded)
        {
            endGameUI.SetActive(true); // Hiển thị giao diện kết thúc trò chơi
        }
    }
}
