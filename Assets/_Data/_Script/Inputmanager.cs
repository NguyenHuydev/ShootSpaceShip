using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmanager : MonoBehaviour
{
    protected static Inputmanager instance;
    public static Inputmanager Instance { get => instance; }
    [SerializeField]
    public Vector3 MousePosition;
    [SerializeField] private float onFiring;
    public float OnFiring { get => onFiring; }


    private void Awake()
    {
        Inputmanager.instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        GetmousePos();
    }

    private void FixedUpdate()
    {
        this.GetMouseDown();
    }
    protected void GetmousePos()
    {
        this.MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.MousePosition.z = 0;
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");

    }
}
