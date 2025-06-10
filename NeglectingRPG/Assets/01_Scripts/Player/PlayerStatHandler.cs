using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    private float defence;
    private float attackSpeed;
    private float moveSpeed;


    public int Level { get; set; }
    public float Exp { get; set; }
    public float CurrHp { get; set; }
    public float CurrMp { get; set; }
    public float MaxHp { get; set; }
    public float MaxMp { get; set; }
    public float Power { get; set; }
    public float Critical { get; set; }
    public float Defence { get; set; }
    public float AttackSpeed { get; set; }
    public float MoveSpeed { get; set; }

    private void Awake()
    {
        CurrHp = MaxHp;
        CurrMp = MaxMp;
    }

    public void Init()
    {
        Level = 1;
        MaxHp = 500;
        MaxMp = 100;
        Power = 50;
        Critical = 10;
        defence = 5;
        attackSpeed = 5;
        moveSpeed = 1;
    }

}
