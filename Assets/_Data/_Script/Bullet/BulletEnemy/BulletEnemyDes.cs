using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletEnemyDes : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D rigidbodyBullet;
    [SerializeField] SpawnBulletEnemy spawnBulletEnemy;
    private void Reset()
    {
        LoadComponents();
    }

    private void Awake()
    {
        if (spawnBulletEnemy != null) return;
        spawnBulletEnemy = FindObjectOfType<SpawnBulletEnemy>();
        if (spawnBulletEnemy == null) Debug.LogWarning("spawnBulletEnemy of RandomBulletEnemy Null");
    }

    protected virtual void LoadComponents()
    {
        LoadCollider();
        LoadRigibody2D();
    }
    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.05f;


    }
    protected virtual void LoadRigibody2D()
    {
        if (this.rigidbodyBullet != null) return;
        this.rigidbodyBullet = GetComponent<Rigidbody2D>();
        this.rigidbodyBullet.isKinematic = true;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "ShipDameReceive")
        {
            spawnBulletEnemy.DesPawnOfPool(transform.parent);
        }

    }


}
