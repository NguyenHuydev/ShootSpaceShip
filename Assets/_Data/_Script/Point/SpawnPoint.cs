using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPoint : LoadPoint       
{
    //[SerializeField] protected List<Transform> spawnPoint;
    // Start is called before the first frame update

    public Transform GetRamdomPoint(string direction)
    {
        int rand;
        switch (direction)
        {  
            case "left+right":
                 rand = Random.Range(5, 8);
                break;
            case "down":
                 rand = Random.Range(1, 5);
                break;
            default:
                 rand = Random.Range(1, 5);
                break;
        } 
        return Point[rand]; 
    }

    public Transform GetTranformPoint(int min, int max)
    {
        int rand;
        rand = Random.Range(min, max);
        return Point[rand];
    }
}
