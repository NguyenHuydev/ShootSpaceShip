using UnityEngine;

public class EnemySpawner : Spawner
{

    /// //////////////////

    protected static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance;}

    [SerializeField] protected int spawnerCount;
    [SerializeField] public int SpawnerCount { get => spawnerCount; }
    /// /////////////////// <summary>
    /// ///////////////////


    protected void Awake()
    {

        EnemySpawner.instance = this;

    }
    protected void Start()
    {
        /*Instance.spawnerCount = 0;*/
        this.spawnerCount = 0;
    }
    public override Transform Spawn(Vector3 positionMeteorite, int type)
    {
        Transform newprefab = Instantiate(prefabSpawner[type], positionMeteorite, Quaternion.identity);
        newprefab.parent = this.holder;
        this.spawnerCount++;
        return newprefab;
       
    }
}
