using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabSpawner;
    [SerializeField] protected List<Transform> poolObject;

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
    public Transform Spawn(Vector3 positionSpawner, int type)
    {
        Transform newprefab = this.GetObjectFromPool(prefabSpawner[type]);// check newprefab has in Pool?
        if (newprefab == null) // don't object in Pool
        {

            newprefab = Instantiate(prefabSpawner[type], positionSpawner, Quaternion.identity);
            newprefab.name = prefabSpawner[type].name;
        }
        else
        {
            newprefab.SetLocalPositionAndRotation(positionSpawner, Quaternion.identity); // set posotion for Bullet
            newprefab.gameObject.SetActive(true);
        }
        newprefab.parent = this.holder;
        return newprefab;
    }
    private Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolobj in poolObject)
        {
            if (poolobj.name == prefab.name)
            {
                this.poolObject.Remove(poolobj);
                return poolobj;
            }
        }
        return null;
    }
    public virtual void DesPawnOfPool(Transform Obj)
    {
        this.poolObject.Add(Obj); //add object of pool
        Obj.gameObject.SetActive(false); //      

    }
}
