using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{

    [Header("Spawner")]
    [SerializeField] private Transform holder;
    [SerializeField] private List<Transform> prefabSpawner;
    


    protected static SpawnItem instance;
    public static SpawnItem Instance { get => instance; }


    protected void Awake()
    {
        if (SpawnItem.instance != null) Debug.LogWarning("SpawnItem.instance not Null");
        SpawnItem.instance = this;
 
    }
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }
    protected virtual void LoadComponent()
    {
        this.LoadPrefabs();

    }
    protected virtual void LoadPrefabs()
    {
        //if (this.prefabsBullet.Count > 0) return;

        Transform prefabtemp = transform.Find("Prefab");
        foreach (Transform temp in prefabtemp)
        {
            this.prefabSpawner.Add(temp);
        }
        this.HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (var temp in prefabSpawner)
        {
            temp.gameObject.SetActive(false);
        }
    }
    public Transform Spawn(Vector3 positionSpawner, int type)
    {
        Transform newprefab = prefabSpawner[type];
        newprefab = Instantiate(prefabSpawner[type], positionSpawner, Quaternion.identity);
        newprefab.parent = this.holder;
        return newprefab;
    }

    public bool RatioSpawn(int ratioSpawn)
    {
        int rand = UnityEngine.Random.Range(0, 100); // 10%
        if (rand<= ratioSpawn)
        {
            return true;
        }
        return false;
    }
}
