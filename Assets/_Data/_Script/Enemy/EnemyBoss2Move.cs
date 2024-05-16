using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBoss2Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] int direction = 1;
    [SerializeField] float speed ;
    private void Start()
    {
        speed = 1f;
        MoveSpeed = 2f;
        targetPosition = new Vector3(0, 2.5f, 0);
        Moving();
    }
    private void FixedUpdate()
    {
        Moving();
        TargetPositionMove();
    }

    private void TargetPositionMove()
    {
        Vector3 Pos = targetPosition;
        Pos.x += direction * speed * Time.fixedDeltaTime;
        targetPosition = Pos;

        if (Pos.x > 1)
        {
            direction = -1;
        }
        else if (Pos.x < -1)
        {
            direction = 1;
        }
    }
    protected virtual void Moving()
    {
            Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
            transform.parent.position = newPos;
    }
}
