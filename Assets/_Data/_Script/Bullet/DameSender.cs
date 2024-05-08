using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : MonoBehaviour
{
   // [SerializeField] protected float damege;
    [SerializeField] protected int typeFx = 1;
    //dsa
    // Start is called before the first frame update
    private void Update()
    {
        LoadValue();
    }

    private void LoadValue()
    {
       // this.damege = BulletManager.Instance.Bullet
    }
    public virtual void Send(Transform obj)
    {
        //DameReceive dameRecevie = obj.GetComponent<DameReceive>();
        EnemyDameReceive dameRecevie = obj.GetComponentInChildren<EnemyDameReceive>();
        if (dameRecevie == null) return;

        this.Send(dameRecevie);
    }

    public virtual void Send(EnemyDameReceive dameRecevie)
    {
        dameRecevie.Deduct(BulletManager.Instance.BulletDamege);
        this.DestroyObject();

    }

    protected virtual void DestroyObject()
    {
        Transform newprefab = FXSpawner.Instance.Spawn(transform.parent.position, typeFx);// spawn enemy
        newprefab.gameObject.SetActive(true);
        //Destroy(transform.parent.gameObject);
        BulletSpawner.Instance.DesPawnOfPool(transform.parent);

    }
}
