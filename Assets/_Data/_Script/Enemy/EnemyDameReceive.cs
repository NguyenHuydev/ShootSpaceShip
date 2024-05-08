using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyDameReceive : DameReceive
{
    /*=========================================================================*/
    [SerializeField] private int typeEnemy; // type enemy rank?

    [SerializeField] private int _scoreEnemy;
    public float ScoreEnemy => _scoreEnemy;

    [SerializeField] private int typeFx;
    /*=========================================================================*/
    private ScoreManager gameManager;

    private void Awake()
    {
        LoadGameManager();
    }
    /*    // Start is called before the first frame update
        private void Start()
        {
            Reborn();
        }*/
    private void OnEnable()
    {
        Reborn();
    }
    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }
    private void LoadGameManager()
    {
        if (gameManager != null) return;
        gameManager = FindObjectOfType<ScoreManager>();
        if (gameManager == null) Debug.Log("gameManager of " + transform.name + "Null");
    }
    protected string GetNameGameobject()
    {
        return gameObject.transform.parent.name;
    }
    protected void GetTypeEnemy()
    {
        string namObjecttemp = GetNameGameobject();
        switch (namObjecttemp)
        {
            case "ShipEnemyRank1":
                this.typeEnemy = 0;
                break;
            case "ShipEnemyRank2":
                this.typeEnemy = 1;
                break;
            case "ShipEnemyRank3":
                this.typeEnemy = 2;
                break;
            default:
                this.typeEnemy = 0;
                Debug.LogWarning("typeEnemy of EnemyDameReceive null");
                break;
        }

    }

    protected virtual void Reborn()
    {
        GetTypeEnemy();
        int indexLeverEneymy = EnemyManager.Instance.IndexEnemyLever;
        Debug.Log("file:DameReceive indexLeverEneymy :" + indexLeverEneymy);
        this._hpMax = EnemyManager.Instance.EnemySO[typeEnemy].leverEnemy[indexLeverEneymy].HpMax;
        this._scoreEnemy = EnemyManager.Instance.EnemySO[typeEnemy].leverEnemy[indexLeverEneymy].Score;
        this._hPcurrent = this._hpMax;
        typeFx = 0;
    }

    protected virtual void DestroyObject()
    {
        if (_hPcurrent <= 0)
        {
            DesTroyEnemy();
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ShipDameReceive")
        {
            DesTroyEnemy();
        }

    }

    private void DesTroyEnemy()
    {
        //Destroy(transform.parent.gameObject);
        EnemySpawner.Instance.DesPawnOfPool(transform.parent);
        gameManager.UpdateScore(this._scoreEnemy);
        Transform newprefab = FXSpawner.Instance.Spawn(transform.parent.position, typeFx);
        newprefab.gameObject.SetActive(true);
    }
}
