using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBulletEnemy : MonoBehaviour
{
    [SerializeField] protected Transform bullerEnemy;// scrpit nay dang gay ra looix

    [SerializeField] protected Transform holder;
    [SerializeField] protected float timeDelay = 3f;
    [SerializeField] protected float realTime = 0f;

    protected virtual void Reset()
    {
        this.LoadHolder();
    }

    private void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }
    
    protected void Awake()
    {
        //bullerEnemy = GameObject.FindGameObjectWithTag("BulletEnemy").transform;
        if(bullerEnemy ==null) Debug.LogWarning("Tranform bulletEnemy of SpawnBulletEnemy Null");
    }
    protected void FixedUpdate()
    {
        Spawn_BulletEnemy();
    }
    protected void Spawn_BulletEnemy()
    {
        this.realTime += Time.fixedDeltaTime;
        if (this.realTime < this.timeDelay) return;
        this.realTime = 0;
        Vector3 SpawnPos = transform.parent.position;
        Transform newprefab = Instantiate(bullerEnemy, SpawnPos, Quaternion.identity);
        newprefab.parent = this.holder;
    }
}
