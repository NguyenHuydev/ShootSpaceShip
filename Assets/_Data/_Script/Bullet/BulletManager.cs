using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // singleton Bullermanager
    private static BulletManager _instance;
    public static BulletManager Instance { get => _instance; }
    /**********************************************************************/

    [SerializeField] protected List<BulletSO> BulletSO;

    /**********************************************************************/
    [SerializeField] private int _indexBullet;
    public int IndexBullet => _indexBullet;
    [SerializeField] protected int _indexBulletLever;
    public int IndexBulletLever => _indexBulletLever;
    [SerializeField] private float _bulletDamege;
    public float BulletDamege => _bulletDamege;
    [SerializeField] private float _bulletSpeedFly;
    public float BulletSpeedFly => _bulletSpeedFly;
    [SerializeField] private float _bulletSpeedfire;
    public float BulletSpeedfire => _bulletSpeedfire;

    private void Awake()
    {
        if (this.BulletSO == null) Debug.LogWarning("BulletSO of BulletLoadfire NUll");
        BulletManager._instance = this;
    }

    private void Start()
    {
        //this._indexBullet = BulletManager.Instance.BulletSO[1].leverbullet[0].damege;
        this._indexBullet = 0;
        this._indexBulletLever = 0; 
    }

    protected void Update()
    {
        this.LoadValue();
    }

    private void LoadValue()
    {
        this._bulletDamege 
            = BulletManager.Instance.BulletSO[this._indexBullet].leverbullet[IndexBulletLever].damege;

        this._bulletSpeedfire
            = BulletManager.Instance.BulletSO[this._indexBullet].leverbullet[IndexBulletLever].speedfire;
        this._bulletSpeedFly
            = BulletManager.Instance.BulletSO[this._indexBullet].leverbullet[IndexBulletLever].speedfly;
    }
}
