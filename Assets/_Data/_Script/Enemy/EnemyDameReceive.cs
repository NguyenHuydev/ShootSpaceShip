using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyDameReceive : DameReceive
{
    /*=========================================================================*/
    [Header("EnemyDameReceive")]
    [SerializeField] private int _scoreEnemy;
    public float ScoreEnemy => _scoreEnemy;

    [SerializeField] private int typeFx;

    [SerializeField] protected int typeEnemy; // type enemy rank?
    /*=========================================================================*/
    private ScoreManager gameManager;
    [SerializeField] protected SpawnPoint spawnPointRanDom;
    [SerializeField] protected EnemyRamdom enemyrandom;

    private void Awake()
    {
        LoadGameManager();
        LoadSpawnPoint();
        LoadEnemyRandom();
    }
    private void OnEnable()
    {
        Reborn();
    }
    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }
    protected void LoadSpawnPoint()
    {
        if (spawnPointRanDom != null) return;
        spawnPointRanDom = FindObjectOfType<SpawnPoint>();
        if (spawnPointRanDom == null) Debug.LogWarning("spawnPointRanDom of scrpit EnemyRamdom NULL ");
    }
    protected void LoadEnemyRandom()
    {
        if (enemyrandom != null) return;
        enemyrandom = FindObjectOfType<EnemyRamdom>();
        if (enemyrandom == null) Debug.LogWarning("enemyrandom of scrpit EnemyRamdom NULL ");
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
            case "EnemyBoss2":
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ShipDameReceive")
        {
            DesTroyEnemy();
        }

    }

    private void DesTroyEnemy()
    {
        EnemySpawner.Instance.DesPawnOfPool(transform.parent);
        gameManager.UpdateScore(this._scoreEnemy);
        Transform newprefab = FXSpawner.Instance.Spawn(transform.parent.position, typeFx);
        newprefab.gameObject.SetActive(true);

        if (SpawnItem.Instance.RatioSpawn(CheckLeverBullet())) // ti len roi ra vat pham
        {
            int ranTypeItem = UnityEngine.Random.Range(0, 2);
            Transform SpawnPos = spawnPointRanDom.GetTranformPoint(1, 5);
            Transform Newprefab = SpawnItem.Instance.Spawn(SpawnPos.position, ranTypeItem);
            Newprefab.gameObject.SetActive(true);
        }
        enemyrandom._numberEnemy--;
    }

    private int CheckLeverBullet()
    {
        int ratio = 0;
        int numberLeverBullet = BulletManager.Instance.IndexBulletLever;
        if (numberLeverBullet == 0)
        {
            ratio = 15;
            Debug.Log("% la bao nhieu:" + ratio);
        }
        else if (numberLeverBullet == 1)
        {
            
            ratio = 10;
            Debug.Log("% la bao nhieu:" + ratio);
        }
        else if (numberLeverBullet == 2)
        {
            ratio = 6;
            Debug.Log("% la bao nhieu:" + ratio);
        }
        else if (numberLeverBullet == 3)
        {
            ratio = 4;
            Debug.Log("% la bao nhieu:" + ratio);
        }
        else if (numberLeverBullet == 4)
        {
            ratio = 1;
            Debug.Log("% la bao nhieu:" + ratio);
        }
        return ratio;
    }
}
