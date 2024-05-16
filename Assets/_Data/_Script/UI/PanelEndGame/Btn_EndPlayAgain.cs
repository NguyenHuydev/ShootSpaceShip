using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn_EndPlayAgain : MonoBehaviour
{
    public Button btnPlayAgain;

    private void Awake()
    {
        LoadButtonHome();
    }

    private void LoadButtonHome()
    {
        if (btnPlayAgain != null) return;
        btnPlayAgain = GetComponent<Button>();
        if (btnPlayAgain == null) Debug.LogWarning("btnPlayAgain of scrpit Btn_EndPlayAgain NULL ");
    }


    private void Start()
    {
        btnPlayAgain.onClick.AddListener(() =>
        {
            LoadMenu();
        });
    }

    private void LoadMenu()
    {
        SceneManager.LoadSceneAsync("_Data/Scenes/main");
    }
}
