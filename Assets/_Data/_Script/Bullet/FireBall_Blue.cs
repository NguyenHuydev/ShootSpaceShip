using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Blue : MonoBehaviour
{
    [SerializeField] Vector3 direction = Vector3.up;// huuong di chuyen cua vien dan


    private void Update()
    {
        BullMove();// huong di chuyen cua vien dan
    }
    protected void BullMove()
    {
        float speedBullet = BulletManager.Instance.BulletSpeedFly;
        transform.parent.Translate(this.direction * speedBullet* Time.deltaTime);
    }
}
