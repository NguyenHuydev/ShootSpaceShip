using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDesSpawnerbyDistance : DesSpawner
{
    [SerializeField] protected Vector3 disLimit = new Vector3(0, 5, 0); 

    protected override bool CanDesSpawn()
    {  
        Vector3 distance = new Vector3(0, 5, 0);
        if (transform.position.y >= distance.y) return true; //
        return false;
    }

    protected override void DesSpawnObject()
    {
        BulletSpawner.Instance.DesPawnOfPool(transform.parent);
    }
}
