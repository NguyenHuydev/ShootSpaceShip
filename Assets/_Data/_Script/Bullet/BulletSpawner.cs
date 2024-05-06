using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField]  List<Transform> poolObject ;
    /// //////////////////

    protected static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }


    //BulletSpawner.Intance.prefabSpawner // list
    /// ///////////////////
    protected void Awake()
    {
        
        BulletSpawner.instance = this;
       

    }

    public override Transform Spawn(Vector3 positionBullet, int type)
    {
        Transform newprefab = this.GetObjectFromPool(prefabSpawner[type]);// check newprefab has in Pool?
        if(newprefab == null) // don't object in Pool
        {
            
            newprefab = Instantiate(prefabSpawner[type], positionBullet, Quaternion.identity);
            newprefab.name = prefabSpawner[type].name;
        }
        else
        {
            
            newprefab.SetLocalPositionAndRotation(positionBullet, Quaternion.identity); // set posotion for Bullet

        }
        newprefab.parent = this.holder;
        return newprefab;
    }

    protected Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolobj in poolObject)
        {
            if(poolobj.name == prefab.name)
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
