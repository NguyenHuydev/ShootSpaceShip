using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDesSpawnerbyDistance : DesSpawner
{
    [SerializeField] protected Vector3 disLimit = new Vector3(0, 5, 0); 
    //[SerializeField] protected Camera mainCamera;
    // Start is called before the first frame update
    protected override bool CanDesSpawn()
    {  
        Vector3 distance = new Vector3(0, 5, 0);
        if (transform.position.y >= distance.y) return true; //
        return false;
    }
}
