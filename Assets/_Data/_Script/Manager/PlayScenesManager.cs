using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadRound1", 2f);
    }

    void LoadRound1()
    {
        SceneManager.LoadSceneAsync("_Data/Scenes/Round1", LoadSceneMode.Additive);
    }
}
