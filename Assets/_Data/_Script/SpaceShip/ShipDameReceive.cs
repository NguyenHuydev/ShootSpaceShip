using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDameReceive : DameReceive
{

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DesBulletEnemy" || collision.name == "DameReceive")
        {
            Debug.Log(collision.name);
           // Destroy(transform.parent.gameObject);
           
        }

    }
}
