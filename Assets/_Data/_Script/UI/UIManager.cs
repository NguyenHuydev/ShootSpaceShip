using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /***********************************************************/
    [SerializeField] public TextMeshProUGUI textScore;
    [SerializeField] public TextMeshProUGUI textHighScore;
    /***********************************************************/

    private void Awake()
    {
        LoadTextScore();
        LoadTextHighScore();
    }

    private void LoadTextScore()
    {
        if (textScore != null) return;
        if (textScore == null) Debug.LogWarning("_textScore of Scrpit GameManager Null");
    }

    private void LoadTextHighScore()
    {
        if (textHighScore != null) return;
        if (textHighScore == null) Debug.LogWarning("_textHighScore of Scrpit GameManager Null");
    }
}
