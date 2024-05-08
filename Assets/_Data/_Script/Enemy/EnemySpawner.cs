using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    /// //////////////////

    protected static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }
    protected void Awake()
    {
        if (EnemySpawner.instance != null) Debug.LogWarning("EnemySpawner.instance not Null");
        EnemySpawner.instance = this;
    }
}
