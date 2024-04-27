using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] protected float speedMove = 0.05f;
    [SerializeField] Vector3 direction = Vector3.down;
    // Start is called before the first frame update
    [SerializeField] Vector3 start;
    [SerializeField] Vector3 end;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.Moving();
        

        
    }
    protected virtual void Moving()
    {
        transform.Translate(this.direction * this.speedMove * Time.deltaTime);
        if (GetPos())
        {
            transform.position = this.start;
        }
    }

    protected virtual bool GetPos()
    {
        Vector3 Postemp = transform.position;
        if(Postemp.y >= this.end.y) return false;
        return true;
    }
}
