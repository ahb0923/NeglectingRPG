using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    public event Action OnStatChanged;

    private int level;
    private float exp;
    private float gold;

    private float currHp;
    private float currMp;
    private float maxHp;
    private float maxMp;
    private float power;
    private float critical;
    private float defence;
    private float attackSpeed;
    private float moveSpeed;

    public int Level
    {
        get => level;
        set { level = value; OnStatChanged?.Invoke(); }
    }

    public float Exp
    {
        get => exp;
        set { exp = value; OnStatChanged?.Invoke(); }
    }

    public float Gold
    {
        get => gold;
        set { gold = value; OnStatChanged?.Invoke(); }
    }

    public float CurrHp
    {
        get => currHp;
        set { currHp = value; OnStatChanged?.Invoke(); }
    }

    public float CurrMp
    {
        get => currMp;
        set { currMp = value; OnStatChanged?.Invoke(); }
    }

    public float MaxHp
    {
        get => maxHp;
        set { maxHp = value; OnStatChanged?.Invoke(); }
    }

    public float MaxMp
    {
        get => maxMp;
        set { maxMp = value; OnStatChanged?.Invoke(); }
    }

    public float Power
    {
        get => power;
        set { power = value; OnStatChanged?.Invoke(); }
    }

    public float Critical
    {
        get => critical;
        set { critical = value; OnStatChanged?.Invoke(); }
    }

    public float Defence
    {
        get => defence;
        set { defence = value; OnStatChanged?.Invoke(); }
    }

    public float AttackSpeed
    {
        get => attackSpeed;
        set { attackSpeed = value; OnStatChanged?.Invoke(); }
    }

    public float MoveSpeed
    {
        get => moveSpeed;
        set { moveSpeed = value; OnStatChanged?.Invoke(); }
    }
 
    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Level = 1;
        Exp = 1;
        Gold = 0;
        MaxHp = 500;
        MaxMp = 100;
        Power = 50;
        Critical = 10;
        defence = 5;
        attackSpeed = 5;
        moveSpeed = 100;
        CurrHp = MaxHp;
        CurrMp = MaxMp;
    }
    public void ApplyModifier(ItemData item)
    {
        if (item?.baseData == null) return;

        Power += item.baseData.power;
        Defence += item.baseData.defence;
        Critical += item.baseData.critical;
        AttackSpeed += item.baseData.attackSpeed;
        MoveSpeed += item.baseData.moveSpeed;
        MaxHp += item.baseData.maxHp;
        MaxMp += item.baseData.maxMp;

        OnStatChanged?.Invoke();
    }

    public void RemoveModifier(ItemData item)
    {
        if (item?.baseData == null) return;
        Power -= item.baseData.power;
        Defence -= item.baseData.defence;
        Critical -= item.baseData.critical;
        AttackSpeed -= item.baseData.attackSpeed;
        MoveSpeed -= item.baseData.moveSpeed;
        MaxHp -= item.baseData.maxHp;
        MaxMp -= item.baseData.maxMp;

        OnStatChanged?.Invoke();
    }
}
