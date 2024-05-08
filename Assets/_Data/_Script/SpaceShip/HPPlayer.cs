using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPPlayer : MonoBehaviour
{
    [SerializeField] protected Slider sliderhp;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected ShipDameReceive shipDameReceive;

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
        LoaddamReceivePlayer();
    }
    private void LoadSilerhp()
    {
        if (sliderhp != null) return;
        sliderhp = GetComponent<Slider>();
        if (sliderhp == null) Debug.Log("sliderhp of Scrpit SliderHP NUll");
    }
    private void LoaddamReceivePlayer()
    {
        if (shipDameReceive != null) return;
        shipDameReceive = FindObjectOfType<ShipDameReceive>();
        if (shipDameReceive == null) Debug.Log("shipDameReceive of Scrpit SliderHP NUll");
    }

    protected void HPShowing()
    {
        this.maxHp = shipDameReceive.HPMAx;
        this.currentHp = shipDameReceive.HPcurrent;
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
