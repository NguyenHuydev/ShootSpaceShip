using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class DameReceive : MonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D rigidbodyBullet;

    [SerializeField] private int typeEnemy;
    [SerializeField] private float _hPcurrent;
    public float HPcurrent => _hPcurrent;

    [SerializeField] private float _hpMax;
    public float HPMAx => _hpMax;
    [SerializeField] private int _scoreEnemy;
    public float ScoreEnemy => _scoreEnemy;

    [SerializeField] private int typeFx;
    /*=========================================================================*/
    private ScoreManager gameManager;

    private void Reset()
    {
        LoadComponents();
    }

    private void Awake()
    {
        LoadGameManager();
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

    private void LoadGameManager()
    {
        if (gameManager != null) return;
        gameManager = FindObjectOfType<ScoreManager>();
        if (gameManager == null) Debug.Log("gameManager of "+transform.name+"Null");
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

    protected string GetNameGameobject()
    {
        string objectName = gameObject.transform.parent.name;
        return objectName;
    }
    protected void GetTypeEnemy()
    {
        string namObjecttemp = GetNameGameobject();
        switch (namObjecttemp)
        {
            case "ShipEnemyRank1(Clone)":
                this.typeEnemy = 0;
                break;
            case "ShipEnemyRank2(Clone)":
                this.typeEnemy = 1;
                break;
            case "ShipEnemyRank3(Clone)":
                this.typeEnemy = 2;
                break;

            default:
                break;
        }

    }

    protected virtual void Reborn()
    {
        GetTypeEnemy();
        int indexLeverEneymy = EnemyManager.Instance.IndexEnemyLever;
        Debug.Log("file:DameReceive indexLeverEneymy :" + indexLeverEneymy);
        this._hpMax = EnemyManager.Instance.EnemySO[typeEnemy].leverEnemy[indexLeverEneymy].HpMax;
        this._scoreEnemy = EnemyManager.Instance.EnemySO[typeEnemy].leverEnemy[indexLeverEneymy].Score;
        this._hPcurrent =this._hpMax;
        typeFx = 0;
    }


    public virtual void Deduct(float deduct)
    {
        
        this._hPcurrent -= deduct;
        if (this._hPcurrent < 0) this._hPcurrent = 0;
        
    }

    protected virtual bool Isdead()
    {
        return this._hPcurrent <= 0;
    }

    protected virtual void DestroyObject()
    {
        if (_hPcurrent <= 0)
        {
            Destroy(transform.parent.gameObject);
            gameManager.UpdateScore(this._scoreEnemy);
            Transform newprefab = FXSpawner.Instance.Spawn(transform.parent.position, typeFx);
            newprefab.gameObject.SetActive(true);
        }
    }
}
