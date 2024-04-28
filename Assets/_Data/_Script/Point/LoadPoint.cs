using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPoint : MonoBehaviour
{
    [Header("LoadPoint")]
    [SerializeField] protected List<Transform> Point;
    protected void Reset()
    {
        LoadPosSpawnPoint();
    }

    protected virtual void LoadPosSpawnPoint()
    {
        Transform prefabtemp = transform.Find("Prefab");
        foreach (Transform temp in prefabtemp)
        {
            this.Point.Add(temp);
        }

    }
}
