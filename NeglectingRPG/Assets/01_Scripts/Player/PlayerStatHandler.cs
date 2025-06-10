using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    private int level;
    private int exp;
    private float hp;
    private float currHp;
    private float currMp;
    private float maxHp;
    private float maxMp;
    private float power;
    private float critical;
    private float defence;
    private float attackSpeed;
    private float moveSpeed;


    public int Level { get; set; }

    public float Exp { get; set; }

    public float CurrHp => currHp;

    public float CurrMp => currMp;

    public float MaxHp { get; set; }
    public float MaxMp { get; set; }

    private void Awake()
    {
        currHp = maxHp;
        currMp = maxMp;


    }

}
