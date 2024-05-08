using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    /// //////////////////
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    /// ///////////////////
    protected void Awake()
    {
        if (BulletSpawner.instance != null) Debug.LogWarning("BulletSpawner.instance not Null");
        BulletSpawner.instance = this;
    }
}
