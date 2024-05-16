using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletEnemy : MonoBehaviour
{
    [Header("RandomBulletEnemy")]
    [SerializeField] protected float timeDelay = 3f;
    [SerializeField] protected float realTime = 0f;

    [SerializeField] protected SpawnBulletEnemy _spawnBulletEnemy;

    protected void Awake()
    {
        if (_spawnBulletEnemy != null) return;
        _spawnBulletEnemy = FindObjectOfType<SpawnBulletEnemy>();
        if (_spawnBulletEnemy == null) Debug.LogWarning("_spawnBulletEnemy of RandomBulletEnemy Null");
    }

    private void FixedUpdate()
    {
        Spawn_BulletEnemy();
    }
    private void Spawn_BulletEnemy()
    {
        this.realTime += Time.fixedDeltaTime;
        if (this.realTime < this.timeDelay) return;
        this.realTime = 0;
        Vector3 SpawnPos = transform.position;
        Transform newprefab = _spawnBulletEnemy.Spawn(SpawnPos, 0);
        newprefab.gameObject.SetActive(true);

    }
}
