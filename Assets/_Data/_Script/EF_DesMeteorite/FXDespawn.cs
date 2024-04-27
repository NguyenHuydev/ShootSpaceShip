using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DesSpawner
{
    [SerializeField] protected float delay;
    [SerializeField] protected float time;

    protected void Start()
    {
        this.delay = 1f;
    }
    protected void OnEnable()
    {
        ResetTimer();
    }

    protected void ResetTimer()
    {
        this.time = 0;
    }
    protected override bool CanDesSpawn()
    {
        this.time += Time.fixedDeltaTime;
        if (this.time >= this.delay) return true;
        return false;
    }
}
