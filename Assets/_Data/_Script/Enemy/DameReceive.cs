using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class DameReceive : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D rigidbodyBullet;


    [SerializeField] private float hp;
    [SerializeField] private float hpMin = 10f;
    [SerializeField] private float hpMax = 20f;
    [SerializeField] private int typeFx;
    /*=========================================================================*/
    private void Reset()
    {
        LoadComponents();
    }
    // Start is called before the first frame update
    private void Start()
    {
        Reborn();

    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }
    protected virtual void LoadComponents()
    {
        LoadCollider();
        LoadRigibody2D();
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

    protected virtual void Reborn()
    {
        this.hp = Random.Range(this.hpMin, this.hpMax);
        typeFx = 0;
    }

    public virtual void Deduct(float deduct)
    {
        
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        
    }

    protected virtual bool Isdead()
    {
        return this.hp <= 0;
    }

    protected virtual void DestroyObject()
    {
        if (hp <= 0)
        {
            Destroy(transform.parent.gameObject);
            Transform newprefab = FXSpawner.Instance.Spawn(transform.parent.position, typeFx);
            newprefab.gameObject.SetActive(true);
        }
    }
}
