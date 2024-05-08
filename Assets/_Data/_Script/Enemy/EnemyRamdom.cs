using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRamdom : MonoBehaviour
{
    [SerializeField] private int SpawnerCount;
    [SerializeField] protected float TimeDelay = 1f;
    [SerializeField] protected float RealTimer = 0f;
    [SerializeField] protected int limitMeterite = 20; // limit spawn meteorite
    [SerializeField] protected int typeMeterite = 0;
    [SerializeField] protected SpawnPoint spawnPointRanDom;

    /// ////
    /******************************************************************************/
    protected void Awake()
    {
       LoadComponent();
        

    }
    protected void Start()
    {
        SpawnerCount = 0;
    }
    /******************************************************************************/
    private void LoadComponent()
    {
        LoadSpawnPoint();
    }
    protected void LoadSpawnPoint()
    {
        if(spawnPointRanDom != null) return;
        spawnPointRanDom = FindObjectOfType<SpawnPoint>();
        if(spawnPointRanDom == null) Debug.LogWarning("spawnPointRanDom of scrpit EnemyRamdom NULL ");
    }

    protected void FixedUpdate()
    {
        this.RealTimer += Time.fixedDeltaTime;
        if (this.RealTimer < this.TimeDelay) return;
        this.RealTimer = 0;
        EnemySpawning();
    }  
    protected virtual void EnemySpawning()
    {
        if (!this.RandomReachLimit()) return; // check Enemy spawn has reached limit
        Transform ranpoint = spawnPointRanDom.GetRamdomPoint();// Position of point 
        Transform newprefab = EnemySpawner.Instance.Spawn(ranpoint.position, typeMeterite);
        SpawnerCount++;
        newprefab.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        if(SpawnerCount >= limitMeterite) return false;
        return true;
    }

}
