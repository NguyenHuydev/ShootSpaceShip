using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Bullet", menuName = "SO/Bullet")] 
public class BulletSO : ScriptableObject
{
    //day la nhung thuoc tinh cua vien dan
    public int IdBuller;
    public Sprite image;
    public List<LeverBullet> leverbullet;
}
