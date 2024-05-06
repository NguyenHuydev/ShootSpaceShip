using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletImpart : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D rigidbodyBullet;
    [SerializeField] protected DameSender dameSender;
    protected void Awake()
    {
        LoadDameSender();
    }
    private void Reset()
    {
        LoadComponents();
    }


    protected virtual void LoadComponents()
    {
        LoadCollider();
        LoadRigibody2D();
        
    }

    protected virtual void LoadDameSender()
    {
        if (this.dameSender != null) return;
        this.dameSender = FindObjectOfType<DameSender>();
        if (dameSender == null) Debug.LogWarning("dameSender of Scrpit BulletIMpart Null");
    }

    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.05f;

    
    }

    protected virtual void LoadRigibody2D()
    {
        if (this.rigidbodyBullet != null) return;
        this.rigidbodyBullet = GetComponent<Rigidbody2D>();
        this.rigidbodyBullet.isKinematic = true;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "DameReceive")
        {
            Debug.Log(collision.name);
            this.dameSender.Send(collision.transform);
        }
        
    }

}
