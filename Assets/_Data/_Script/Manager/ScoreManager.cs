using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score ;
    public int Score => _score;
    [SerializeField] private int _highScore;
    public int HighScore => _highScore;



    [SerializeField] protected DataGamePlay _dataGamePlay;
    [SerializeField] protected UIManager uiManager;
    /*********************************************************************************/
    private void Awake()
    {
 
        LoadDataGamePlay();
        LoadUIManaer();
    }
    private void Start()
    {
  
        UpdateScore(0);
        _highScore = _dataGamePlay.GetHighScore(); // lay ra highScore trong data
        ShowTextScore();

    }
    /*********************************************************************************/
    private void LoadDataGamePlay()
    {
        if (_dataGamePlay != null) return;
        _dataGamePlay = FindObjectOfType<DataGamePlay>();
        if (_dataGamePlay == null) Debug.LogWarning("_dataGamePlay of Scrpit GameManager Null");
    }
    protected void LoadUIManaer()
    {
        if (uiManager != null) return;
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null) Debug.LogWarning("uiManager of Scrpit UIManager Null");
    }

    protected void ShowTextScore()
    {
        uiManager.textScore.SetText("Score " + _score.ToString());
        uiManager.textHighScore.SetText("HighScore " + _highScore.ToString());
    }
    public void UpdateScore(int score)
    {
        _score += score;
        if (_score > _highScore)
        {
            _highScore = _score;
            ////////////////////////
            _dataGamePlay.AddHighScore(_highScore);
        }
        ShowTextScore();
    }


}
