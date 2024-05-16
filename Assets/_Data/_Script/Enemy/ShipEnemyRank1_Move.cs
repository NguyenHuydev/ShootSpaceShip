using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShipEnemyRank1_Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    [SerializeField] private Transform targetObject;

    private void Awake()
    {
        LoadTagetObject();
    }
    private void OnEnable()
    {
        GetDirection();
    }
    private void Update()
    {
        BullMove();
    }

    private void LoadTagetObject()
    {
        if (targetObject != null) return;
        if (targetObject == null) Debug.LogWarning("targetObject of scrpit EnemyRamdom NULL ");
    }
    protected void FixedUpdate()
    {
        //Rotating();
    }

    private void GetDirection()
    {
        
        if (targetObject == null)
        {
            direction = Vector3.down;
        }
        else
        {
            Vector3 PosPlayer = targetObject.position;
            direction = (PosPlayer - transform.position).normalized;
            //Quaternion targetRotation = Quaternion.LookRotation(direction);
           // transform.rotation = targetRotation;
            //Debug.Log("abc là" + angle);
        }
    }
    protected void BullMove()
    {
  
        transform.parent.Translate(direction * this.speed * Time.deltaTime);
        
    }


/*    protected virtual void GetFlyDirection()
    {
        Vector3 objPos = transform.parent.position;
        objPos.Normalize();
        float rot_z = Mathf.Atan2(objPos.y, objPos.x) * Mathf.Rad2Deg;
        //transform.parent.position
        Debug.DrawLine(objPos, objPos * 7, Color.red, Mathf.Infinity);
    }*/

/*    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0,0,1);
        transform.Rotate(eulers * this.rotaSpeed * Time.fixedDeltaTime);
    }*/
}
