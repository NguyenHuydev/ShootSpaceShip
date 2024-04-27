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
    protected SpawnPoint spawnPointRanDom;
    

    /// ////

    protected void Awake()
    {
        spawnPointRanDom = FindObjectOfType<SpawnPoint>();
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
        if (!this.RandomReachLimit()) return; // check meteorite spawn has reached limit
        Transform ranpoint = spawnPointRanDom.GetRamdomPoint();
        Vector3 positon = transform.position;
        Quaternion rot = transform.rotation;
        Transform newprefab = EnemySpawner.Instance.Spawn(ranpoint.position, typeMeterite);
        newprefab.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        if(EnemySpawner.Instance.SpawnerCount >=limitMeterite) return false;
        return true;
    }

}
