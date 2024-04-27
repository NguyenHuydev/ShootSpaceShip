using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  DesSpawner : MonoBehaviour
{

    protected void FixedUpdate()
    {
        this.DesSpawning();
    }

    protected virtual void DesSpawning()
    {
        if (!this.CanDesSpawn()) return;
        this.DesSpawnObject();
    }

    protected virtual void DesSpawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    
    protected abstract bool CanDesSpawn();
    
   
}
