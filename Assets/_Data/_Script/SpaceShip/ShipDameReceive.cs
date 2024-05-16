using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDameReceive : DameReceive
{
    private PlayScenesManager CheckEndGame;
    private void Awake()
    {
        LoadCheckEndGame();
    }
    private void OnEnable()
    {
        Reborn();
    }
    private void Reborn()
    {
        this._hpMax = 100;
        this._hPcurrent = this._hpMax;
    }


    private void LoadCheckEndGame()
    {
        if (CheckEndGame != null) return;
        CheckEndGame = FindObjectOfType<PlayScenesManager>();
        if (CheckEndGame == null) Debug.LogWarning("CheckEndGame of scrpit ShipDameReceive NULL ");
    }

    protected void OnTriggerEnter2D(Collider2D collision) // Ship Collision vs Enemy end Item
    {
        if (collision.name == "DesBulletEnemy" || collision.name == "DameReceive")
        {
            CollideShip();
            if (_hPcurrent <= 0)
            {
                CheckEndGame.gameEnded = true; //dang loi o day
                DestroyObject();
                //Invoke("DestroyObject()", 2f);

            }
        }
        if(collision.name == "CollisionItemLever")
        {
            
            BulletManager.Instance.GetIndexBulletLever(1);
        }
        if (collision.name == "CollisionItemHealing")
        {

            this._hPcurrent += 20;
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
