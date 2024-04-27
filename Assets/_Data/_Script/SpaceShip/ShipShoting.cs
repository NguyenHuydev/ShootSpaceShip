using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float BulletSpeedFire ;
    [SerializeField] protected float CounterTime = 0f;
    [SerializeField] protected int typeBuleet;
    //[SerializeField] protected Transform bulletPrefab;
    // Update is called once per frame

    void FixedUpdate()
    {
        this.Shooting();
        
    }
    protected virtual void Shooting()
    {
        if (Inputmanager.Instance.OnFiring==0) return;

        this.typeBuleet = BulletManager.Instance.IndexBullet; 
        this.BulletSpeedFire = BulletManager.Instance.BulletSpeedfire;

        this.CounterTime += Time.fixedDeltaTime;
        if (this.CounterTime < this.BulletSpeedFire) return;
        this.CounterTime = 0;

        //if (!this.isShooting) return; 
        Vector3 SpawnPos = transform.parent.position;
        Transform newprefab =  BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
        newprefab.gameObject.SetActive(true);
       
    }
    

}

