using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataGamePlay : MonoBehaviour
{
    private string ALL_DATAGAME = "DataGame"; // key save data in PlayerPrefs
    [SerializeField]private AllData _allDataGame; // data in game
    private void Awake()
    {
        GetDataJson();
    }



    protected void GetDataJson()
    {
        // chuyen doi dũ lieu tu json sang allData
        // láy dữ liệu tư playerprefs ra và sử dụng
        var _allDataGameTemp = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATAGAME));

        if (_allDataGameTemp == null)
        {
            AddHighScore(0);
        }
        else
        {
            _allDataGame = _allDataGameTemp;
        }
    }

        

        private void SaveData()
        {
            // luu data vao Json
            // chuyen doi dũ lieu tu data sang Json
            string Json = JsonUtility.ToJson(_allDataGame);
            // luu data json vao PlayerPrefs
            PlayerPrefs.SetString(ALL_DATAGAME, Json);
        }

        public void AddHighScore(int hightScore)
        {
            _allDataGame.highScore = hightScore;
            SaveData();
        }
        public int GetHighScore()
        {
            int highScore = _allDataGame.highScore;
            return highScore;
        }


    }
