using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected void FixedUpdate()
    {
        Following();
    }

    protected void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, speed * Time.fixedDeltaTime);
    }
}
