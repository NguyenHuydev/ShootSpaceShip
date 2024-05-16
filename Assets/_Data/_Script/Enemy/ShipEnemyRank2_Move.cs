using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemyRank2_Move : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] int directionX = 1;
    [SerializeField] int directionY = 1;
    private Vector3 PosEnemyStart;

    private void Start()
    {
        speedX = 1f;
        speedY = 0.6f;
        PosEnemyStart = transform.parent.position;
    }
    private void FixedUpdate()
    {
        MoveLeft();
       // BullMove();
    }

    protected void BullMove()
    {
        float sin = Mathf.Sin(PosEnemyStart.x) ; 
       // transform.parent.position = PosEnemyStart + new Vector3(0, sin, 0);

    }
    protected void MoveLeft()
    {
        Vector3 Pos = transform.parent.position;
        Pos.x += directionX * speedX * Time.fixedDeltaTime;
        Pos.y += directionY * speedY * Time.fixedDeltaTime;
        transform.parent.position = Pos;
        // kiem soat vi tri X
        if (Pos.x >4)
        {
            directionX = -1;
        }
        else if(Pos.x < -4)
        {
            directionX = 1;
        }
        // kiem soat vi tri y
        if (Pos.y > (PosEnemyStart.y + 0.2f))//
        {
            directionY = -1;
        }
        else if (Pos.y < (PosEnemyStart.y - 0.2f))//
        {
            directionY = 1;
        }

    }
}
