using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    //day la nhung thuoc tinh cua vien dan
    public int IdEnemy;
    public string nameEnemy;
    public List<LeverEnemy> leverEnemy;
}
