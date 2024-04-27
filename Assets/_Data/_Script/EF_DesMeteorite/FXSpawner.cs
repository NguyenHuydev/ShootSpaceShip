using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }
    /////////////////// 
    ///////////////////


    protected void Awake()
    {

        FXSpawner.instance = this;

    }
    public override Transform Spawn(Vector3 positionMeteorite, int typeFX)
    {
        Transform newprefab = Instantiate(prefabSpawner[typeFX], positionMeteorite, Quaternion.identity);
        newprefab.parent = this.holder;
        return newprefab;

    }
}
