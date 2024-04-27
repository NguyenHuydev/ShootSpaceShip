using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemy_Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotaSpeed;
    [SerializeField] Vector3 direction = Vector3.down;


    private void Update()
    {
        BullMove();
    }

    protected void FixedUpdate()
    {
        Rotating();
    }
    protected void BullMove()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
    }

/*    protected virtual void GetFlyDirection()
    {
        Vector3 objPos = transform.parent.position;
        objPos.Normalize();
        float rot_z = Mathf.Atan2(objPos.y, objPos.x) * Mathf.Rad2Deg;
        //transform.parent.position
        Debug.DrawLine(objPos, objPos * 7, Color.red, Mathf.Infinity);
    }*/

    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0, 1);
        transform.Rotate(eulers * this.rotaSpeed * Time.fixedDeltaTime);
    }
}
