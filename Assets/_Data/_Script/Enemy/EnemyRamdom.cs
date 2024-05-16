using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class EnemyRamdom : MonoBehaviour
{
    [SerializeField] private int SpawnerCount;
    [SerializeField] public int _numberEnemy = 0;
    [SerializeField] protected float TimeDelay = 1f;
    [SerializeField] protected float RealTimer = 0f;
    [SerializeField] protected int limitMeterite = 20; // limit spawn meteorite
    [SerializeField] protected int typeMeterite = 0;
    [SerializeField] protected SpawnPoint spawnPointRanDom;
    [SerializeField] protected PlayScenesManager playScenesManager;
    private bool Boss2Spawn = false;

    /// ////
    /******************************************************************************/
    protected void Awake()
    {
       LoadComponent();
        

    }
    protected void Start()
    {
        SpawnerCount = 0;
        _numberEnemy = 0;
    }
    /******************************************************************************/
    private void LoadComponent()
    {
        LoadSpawnPoint();
        LoadPlayScenesManager();
    }
    protected void LoadSpawnPoint()
    {
        if(spawnPointRanDom != null) return;
        spawnPointRanDom = FindObjectOfType<SpawnPoint>();
        if(spawnPointRanDom == null) Debug.LogWarning("spawnPointRanDom of scrpit EnemyRamdom NULL ");
    }
    protected void LoadPlayScenesManager()
    {
        if (playScenesManager != null) return;
        playScenesManager = FindObjectOfType<PlayScenesManager>();
        if (playScenesManager == null) Debug.LogWarning("spawnPointRanDom of scrpit EnemyRamdom NULL ");
    }

    protected void FixedUpdate()
    {
        if (!playScenesManager.gameEnded)
        {
            GamePlay();
        }
        
    }  
    protected virtual void EnemySpawning()
    {
        int typeEnemy = Random.Range(0, 2);
        Transform ranpoint ;
        if (typeEnemy == 0)
        {
             ranpoint = spawnPointRanDom.GetRamdomPoint("down");// Position of point 
        }else if(typeEnemy == 1)
        {
             ranpoint = spawnPointRanDom.GetRamdomPoint("left+right");// Position of point 
        }
        else
        {
            ranpoint = spawnPointRanDom.GetRamdomPoint("down");// Position of point 
        }

        Transform newprefab = EnemySpawner.Instance.Spawn(ranpoint.position, typeEnemy);//
        SpawnerCount++;
        newprefab.gameObject.SetActive(true);
    }

    protected void GamePlay()
    {
        if(SpawnerCount <= 3 && _numberEnemy <=5)
        {
            this.RealTimer += Time.fixedDeltaTime;
            if (this.RealTimer < this.TimeDelay) return;
            this.RealTimer = 0;
            _numberEnemy++;
            EnemySpawning();
        }
        else if(!Boss2Spawn && _numberEnemy <= 0)
        {
            // SpawnBoss();
            Invoke("SpawnBoss", 5f);
            Boss2Spawn = true;
        }

    }
    private void SpawnBoss()
    {
        Transform ranpoint = spawnPointRanDom.GetTranformPoint(0, 0);
        Transform newprefab = EnemySpawner.Instance.Spawn(ranpoint.position, 2);
        newprefab.gameObject.SetActive(true);
        
    }

    protected virtual bool RandomReachLimit(int QuantityEnemy)
    {
        if(QuantityEnemy==0) return false;
        return true;
    }

}
