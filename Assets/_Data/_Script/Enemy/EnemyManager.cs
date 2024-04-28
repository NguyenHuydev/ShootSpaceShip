using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // singleton Bullermanager
    private static EnemyManager _instance;
    public static EnemyManager Instance { get => _instance; }
    /**********************************************************************/

    [SerializeField] public List<EnemySO> EnemySO;



    /**********************************************************************/

    [SerializeField] private int _indexEnemyLever;
    public int IndexEnemyLever => _indexEnemyLever;



    private void Awake()
    {
        if (this.EnemySO == null) Debug.LogWarning("EnemySO of BulletLoadfire NUll");
        EnemyManager._instance = this;
    }


    protected void Update()
    {
        this.LoadValue();
    }

    private void LoadValue()
    {
/*        this._enemyHPMax
            = EnemyManager.Instance.EnemySO[this._indexEnemy].leverEnemy[_indexEnemyLever].HpMax;*/
    }
}
