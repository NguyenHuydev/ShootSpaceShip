using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyDesByDistance : DesSpawner
{
    [SerializeField] protected Vector3 disLimit = new Vector3(0, -6, 0);
    [SerializeField] protected float distance = 0f; //
    [SerializeField] private SpawnBulletEnemy _spawnBulletEnemy;

    // Start is called before the first frame update
    protected void Awake()
    {
        if (_spawnBulletEnemy != null) return;
        _spawnBulletEnemy = FindObjectOfType<SpawnBulletEnemy>();
        if (_spawnBulletEnemy == null) Debug.LogWarning("_spawnBulletEnemy of RandomBulletEnemy Null");
    }
    protected override bool CanDesSpawn()
    {

        Vector3 distance = new Vector3(0, -6, 0);
        if (transform.position.y <= distance.y) return true; //
        return false;
    }
    protected override void DesSpawnObject()
    {
        _spawnBulletEnemy.DesPawnOfPool(transform.parent);
    }
}
