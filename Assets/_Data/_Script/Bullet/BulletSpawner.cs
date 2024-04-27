using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{

    /// //////////////////

    protected static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }


    //BulletSpawner.Intance.prefabSpawner // list
    /// ///////////////////
    protected void Awake()
    {
        
        BulletSpawner.instance = this;
       

    }

    public override Transform Spawn(Vector3 positionBullet, int type)
    {
        Transform newprefab =  Instantiate(prefabSpawner[type], positionBullet, Quaternion.identity);
        newprefab.parent = this.holder;
        return newprefab;
        
    }

}
