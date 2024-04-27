using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // singleton Bullermanager
    private static EnemyManager _instance;
    public static EnemyManager Instance { get => _instance; }
    /**********************************************************************/

    [SerializeField] protected List<EnemySO> EnemySO;
    /// <summary>
    /// 
    /// </summary>

    /**********************************************************************/
    [SerializeField] private int _indexEnemy;
    public int IndexEnemy => _indexEnemy;
    [SerializeField] private int _indexEnemyLever;
    public int IndexEnemyLever => _indexEnemyLever;
    [SerializeField] private float _enemyHPMax;
    public float EnemyHpMax => _enemyHPMax;


    private void Awake()
    {
        if (this.EnemySO == null) Debug.LogWarning("EnemySO of BulletLoadfire NUll");
        EnemyManager._instance = this;
    }

    private void Start()
    {
        //this._indexBullet = BulletManager.Instance.BulletSO[1].leverbullet[0].damege;
        this._indexEnemy = 0;
        this._indexEnemyLever = 0;
    }

    protected void Update()
    {
        this.LoadValue();
    }

    private void LoadValue()
    {
        this._enemyHPMax
            = EnemyManager.Instance.EnemySO[this._indexEnemy].leverEnemy[_indexEnemyLever].HpMax;
    }
}
