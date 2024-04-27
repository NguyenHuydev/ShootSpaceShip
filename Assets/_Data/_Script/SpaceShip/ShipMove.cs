using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    [SerializeField]
    protected Vector3 targetPosition;
    [SerializeField]
    protected float MoveSpeed = 1.0f;
    [SerializeField] float shipMoveSpeedStart = 2f;
    private bool endShipMoveStart = false;

    protected void ShipMoveStart()
    {
        if (endShipMoveStart) return;
        Vector3 newPos = new Vector3(0, -4f, 0);
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, newPos, shipMoveSpeedStart * Time.deltaTime);
        if (transform.parent.position.y == -4f) endShipMoveStart = true;
    }
    // Update is called once per frame
    void Update()
    {
        GetTargetPosition();
        Invoke("Moving", 3f);
       // Moving();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = Inputmanager.Instance.MousePosition;
        this.targetPosition.z = 0;
        if (targetPosition.x >= 2.6f)
        {
            targetPosition.x = 2.6f;
        }
        else if (targetPosition.x <= -2.6f)
        {
            targetPosition.x = -2.6f;
        }
        if (targetPosition.y >= 4f)
        {
            targetPosition.y = 4;
        }else if(targetPosition.y <= -4.5f)
        {
            targetPosition.y = -4.5f;
        }

    }
    protected virtual void Moving()
    {
        {
            Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
            transform.parent.position = newPos;
        }
    }
}
