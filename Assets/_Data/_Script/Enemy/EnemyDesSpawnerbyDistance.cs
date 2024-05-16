using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesSpawnerbyDistance : DesSpawner
{
    [SerializeField] protected Vector3 disLimit = new Vector3(0, -6, 0);
    [SerializeField] protected float distance = 0f; //  
    // Start is called before the first frame update

    [SerializeField] protected EnemyRamdom enemyrandom;

    private void Awake()
    {
        LoadEnemyRandom();
    }
    protected override bool CanDesSpawn()
    {

        Vector3 distance = new Vector3(0, -6, 0);
        if (transform.position.y <= distance.y) return true; //
        return false;
    }
    protected override void DesSpawnObject()
    {
        EnemySpawner.Instance.DesPawnOfPool(transform.parent);
        enemyrandom._numberEnemy--;
    }

    protected void LoadEnemyRandom()
    {
        if (enemyrandom != null) return;
        enemyrandom = FindObjectOfType<EnemyRamdom>();
        if (enemyrandom == null) Debug.LogWarning("enemyrandom of scrpit EnemyRamdom NULL ");
    }
}
