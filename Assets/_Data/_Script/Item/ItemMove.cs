using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction = Vector3.down;

    private void Update()
    {
        BullMove();
    }

    protected void BullMove()
    {

        transform.parent.Translate(direction * this.speed * Time.deltaTime);

    }
}
