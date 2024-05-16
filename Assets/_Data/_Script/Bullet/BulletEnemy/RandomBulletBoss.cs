using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBulletBoss : MonoBehaviour
{
    [Header("RandomBulletEnemy")]
    [SerializeField] protected float timeDelay = 5f;
    [SerializeField] protected float realTime = 0f;

    [SerializeField] protected float timeDelaySpawnType2 = 0.2f;
    [SerializeField] protected float realTimeSpawnType2 = 0f;

    [SerializeField] private bool IsSpawnType2;
    [SerializeField] private bool IsDone2;
    [SerializeField] private int countSpawnType2;

    [SerializeField] protected SpawnBulletEnemy _spawnBulletEnemy;

    protected void Awake()
    {
        if (_spawnBulletEnemy != null) return;
        _spawnBulletEnemy = FindObjectOfType<SpawnBulletEnemy>();
        if (_spawnBulletEnemy == null) Debug.LogWarning("_spawnBulletEnemy of RandomBulletEnemy Null");
    }
    private void Start()
    {
        IsSpawnType2 = false;
        IsDone2 = true;
        countSpawnType2 = 0;
    }

    private void FixedUpdate()
    {
        if (IsSpawnType2 && !IsDone2)
        {
            Spawn_BulletType2(new Vector3(-3, 5, 0), new Vector3(3, 5, 0), 25);
        }
        Invoke("Spawn_BulletEnemy", 3f);
        
    }


    private void Spawn_BulletEnemy()
    {
        this.realTime += Time.fixedDeltaTime;
        if (this.realTime < this.timeDelay) return;
        this.realTime = 0;
        Spawn_BulletType1(new Vector3(-3, 5, 0), new Vector3(3, 5, 0), 25);
        IsSpawnType2 = true;
        IsDone2 = false;
    }

    private void Spawn_BulletType1(Vector3 startVector, Vector3 endVector, int numDivisionsType1)
    {
        Vector3 currentDirection = transform.forward;
        Vector3 SpawnPos = transform.position;
        // Tính bước chuyển đổi cho mỗi phần
        Vector3 step = (-endVector - startVector) / (numDivisionsType1 - 1);
        // Tạo ra các vector mới
        // Vector3[] dividedVectors = new Vector3[numDivisions];
        for (int i = 0; i < numDivisionsType1; i++)
        {
            //dividedVectors[i] = startVector + i * step;
            Transform newprefab = _spawnBulletEnemy.Spawn(SpawnPos, 1);
            newprefab.forward = currentDirection + startVector + i * step;
            newprefab.gameObject.SetActive(true);
        }
    }

    private void Spawn_BulletType2(Vector3 startVector, Vector3 endVector, int numDivisionsType2)
    {
        IsDone2 = false;
        this.realTimeSpawnType2 += Time.fixedDeltaTime;
        if (this.realTimeSpawnType2 < this.timeDelaySpawnType2) return;
        this.realTimeSpawnType2 = 0;
        Debug.Log("vao dc ham so 2");
        Vector3 currentDirection = transform.forward;
        Vector3 SpawnPos = transform.position;
        // Tính bước chuyển đổi cho mỗi phần
        Vector3 step = (-endVector - startVector) / (numDivisionsType2 - 1);
        // Tạo ra các vector mới

        Transform newprefab = _spawnBulletEnemy.Spawn(SpawnPos, 1);
        newprefab.forward = currentDirection + startVector + countSpawnType2 * step;
        newprefab.gameObject.SetActive(true);
        Debug.Log("vao dc ham so 2");
        countSpawnType2++;
        if (countSpawnType2 == numDivisionsType2)
        {
            IsSpawnType2 = false;
            IsDone2 = true;
            countSpawnType2 = 0;
        }
    }


}
