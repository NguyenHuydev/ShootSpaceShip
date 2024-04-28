using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPoint : LoadPoint       
{
    //[SerializeField] protected List<Transform> spawnPoint;
    // Start is called before the first frame update

    public Transform GetRamdomPoint()
    {
        int rand = Random.Range(1, 5);
        return Point[rand];
       
    }
}
