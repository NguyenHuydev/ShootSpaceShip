using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyMove : MonoBehaviour
{
    [SerializeField] Vector3 direction = Vector3.down;// huuong di chuyen cua vien dan
    [SerializeField] protected float speedBulletEnemy;

    protected void Start()
    {
        speedBulletEnemy = 3f;
    }
    private void Update()
    {
        BullMove();// huong di chuyen cua vien dan
    }
    protected void BullMove()
    {
        transform.parent.Translate(this.direction * speedBulletEnemy * Time.deltaTime);
    }
}
