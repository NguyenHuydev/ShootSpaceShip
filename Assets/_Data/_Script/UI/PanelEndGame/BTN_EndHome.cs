using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BTN_EndHome : MonoBehaviour
{
    public Button btnHome;

    private void Awake()
    {
        LoadButtonHome();
    }

    private void LoadButtonHome()
    {
        if (btnHome != null) return;
        btnHome = GetComponent<Button>();
        if (btnHome == null) Debug.LogWarning("btnHome of scrpit BTN_EndHome NULL ");
    }


    private void Start()
    {
        btnHome.onClick.AddListener(() =>
        {
            LoadMenu();
        });
    }

    private void LoadMenu()
    {
        SceneManager.LoadSceneAsync("_Data/Scenes/StartGame");
    }
}
