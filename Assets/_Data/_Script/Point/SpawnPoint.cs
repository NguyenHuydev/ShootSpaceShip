using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoint;
    // Start is called before the first frame update
    protected void Reset()
    {
        LoadPosSpawnPoint();
    }

    protected virtual void LoadPosSpawnPoint()
    {
        Transform prefabtemp = transform.Find("Prefab");
        foreach (Transform temp in prefabtemp)
        {
            this.spawnPoint.Add(temp);
        }
        
    }

    public Transform GetRamdomPoint()
    {
        int rand = Random.Range(0, this.spawnPoint.Count);
        return spawnPoint[rand];
    }
}
