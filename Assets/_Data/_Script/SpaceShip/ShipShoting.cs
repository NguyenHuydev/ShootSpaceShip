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
        Vector3 SpawnPos = transform.parent.position;
        Vector3 PosLeft1 = SpawnPos + new Vector3(-0.2f, 0, 0);
        Vector3 PosLeft2 = SpawnPos + new Vector3(-0.4f, 0, 0);
        Vector3 PosRight1 = SpawnPos + new Vector3(0.2f, 0, 0);
        Vector3 PosRight2 = SpawnPos + new Vector3(0.4f, 0, 0);

        Transform newprefab;
        Transform newprefab1;
        Transform newprefab2;
        Transform newprefab3;
        Transform newprefab4;

        int IndexLeverShip = GetLeverShip();
        switch (IndexLeverShip)
        {
            case 0:// shoot one
                newprefab = BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
                newprefab.gameObject.SetActive(true);
                break;
            case 1:// shoot two
                newprefab1 = BulletSpawner.Instance.Spawn(PosLeft1, typeBuleet);
                newprefab1.gameObject.SetActive(true);
                newprefab = BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
                newprefab.gameObject.SetActive(true);
                break;
            case 2:// shoot two
                newprefab1 = BulletSpawner.Instance.Spawn(PosLeft1, typeBuleet);
                newprefab1.gameObject.SetActive(true);
                newprefab = BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
                newprefab.gameObject.SetActive(true);
                break;
            case 3:// shoot three
                newprefab1 = BulletSpawner.Instance.Spawn(PosLeft1, typeBuleet);
                newprefab1.gameObject.SetActive(true);
                newprefab2 = BulletSpawner.Instance.Spawn(PosRight1, typeBuleet);
                newprefab2.gameObject.SetActive(true);
                newprefab = BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
                newprefab.gameObject.SetActive(true);
                break;
            case 4: // shoot four
                newprefab1 = BulletSpawner.Instance.Spawn(PosLeft1, typeBuleet);
                newprefab1.gameObject.SetActive(true);
                newprefab2 = BulletSpawner.Instance.Spawn(PosRight1, typeBuleet);
                newprefab2.gameObject.SetActive(true);
                newprefab3 = BulletSpawner.Instance.Spawn(PosRight2, typeBuleet);
                newprefab3.gameObject.SetActive(true);
                newprefab = BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
                newprefab.gameObject.SetActive(true);
                break;
            case 5:// shoot five
                newprefab1 = BulletSpawner.Instance.Spawn(PosLeft1, typeBuleet);
                newprefab1.gameObject.SetActive(true);
                newprefab2 = BulletSpawner.Instance.Spawn(PosRight1, typeBuleet);
                newprefab2.gameObject.SetActive(true);
                newprefab3 = BulletSpawner.Instance.Spawn(PosLeft2, typeBuleet);
                newprefab3.gameObject.SetActive(true);
                newprefab4 = BulletSpawner.Instance.Spawn(PosRight2, typeBuleet);
                newprefab4.gameObject.SetActive(true);
                newprefab = BulletSpawner.Instance.Spawn(SpawnPos, typeBuleet);
                newprefab.gameObject.SetActive(true);
                break;

            default:
                
                Debug.LogWarning("typeEnemy of EnemyDameReceive null");
                break;
        }

       
    }
    private int GetLeverShip()
    {
        return BulletManager.Instance.IndexBulletLever;
    }

}

