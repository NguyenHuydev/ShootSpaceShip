using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDameReceive : DameReceive
{

    private void OnEnable()
    {
        Reborn();
    }
    private void Reborn()
    {
        this._hpMax = 500;
        this._hPcurrent = this._hpMax;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "DesBulletEnemy" || collision.name == "DameReceive")
        {
            CollideShip();
            if (_hPcurrent <= 0)
            {
                DestroyObject();

            }
        }

    }

    private void CollideShip()
    {
        Deduct(20);
    }

    protected virtual void DestroyObject()
    {
         Destroy(transform.parent.gameObject);
    }
}
