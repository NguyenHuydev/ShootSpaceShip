using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabSpawner;

/*    [SerializeField] protected int spawnerCount;
    [SerializeField] public int SpawnerCount { get => spawnerCount; }*/
    
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
    public abstract Transform Spawn(Vector3 positionBullet, int type);
    
}
