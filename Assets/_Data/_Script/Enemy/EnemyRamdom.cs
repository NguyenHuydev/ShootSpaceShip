using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRamdom : MonoBehaviour
{
    [SerializeField] protected float TimeDelay = 1f;
    [SerializeField] protected float RealTimer = 0f;
    [SerializeField] protected int limitMeterite = 20; // limit spawn meteorite
    [SerializeField] protected int typeMeterite = 0;
    [SerializeField] protected SpawnPoint spawnPointRanDom;

    /// ////

    protected void Awake()
    {
       LoadComponent();
        

    }
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
        newprefab.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        if(EnemySpawner.Instance.SpawnerCount >=limitMeterite) return false;
        return true;
    }

}
