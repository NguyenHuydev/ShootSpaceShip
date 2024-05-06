using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LeverBullet
{
    public string NameLever;
    public float damege;
    public float speedfly;
    public float speedfire;
}
[Serializable]
public class LeverEnemy
{
    public string NameLeverEnemy;
    public float HpMax;
    public int Score;

}
[Serializable]
public class AllData
{
    public int highScore;

}