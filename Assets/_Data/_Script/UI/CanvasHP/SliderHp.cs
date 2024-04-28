using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHp : MonoBehaviour
{
    [SerializeField] protected Slider sliderhp;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected DameReceive damReceiveEnemy;



    protected void Awake()
    {
        LoadComponent();
    }

    protected void FixedUpdate()
    {
        HPShowing();

    }
    private void LoadComponent()
    {
        LoadSilerhp();
        LoaddamReceiveEnemy();
    }
    private void LoadSilerhp()
    {
        if (sliderhp != null) return;
        sliderhp = GetComponent<Slider>();
        if (sliderhp == null) Debug.Log("sliderhp of Scrpit SliderHP NUll");
    }
    private void LoaddamReceiveEnemy()
    {
        if (damReceiveEnemy != null) return;
       // sliderhp = GetComponent<Slider>();
        if (damReceiveEnemy == null) Debug.Log("damReceiveEnemy of Scrpit SliderHP NUll");
    }

    protected void HPShowing()
    {
        this.maxHp = damReceiveEnemy.HPMAx;
        this.currentHp = damReceiveEnemy.HPcurrent;
        float hpPercent = this.currentHp / this.maxHp;
        this.sliderhp.value = hpPercent;
    }
/*    public virtual void SetMaxhp(float Maxhp)
    {
        this.maxHp = Maxhp;
    }
    public virtual void SetCurrenthp(float currentHp)
    {
        this.currentHp = currentHp;
    }*/
}
