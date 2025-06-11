using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    public event Action OnStatChanged;
    public event Action OnHpChanged;
    public event Action OnMpChanged;
    public event Action OnExpChanged;

    // 내부 필드
    private float currHp, currMp, maxHp, maxMp;
    private float power, critical, defence, attackSpeed, moveSpeed;
    private float exp, gold;
    private int level;

    // 프로퍼티 - 콜백 연동
    public float CurrHp { get => currHp; set { currHp = Mathf.Clamp(value, 0, MaxHp); OnHpChanged?.Invoke(); } }
    public float CurrMp { get => currMp; set { currMp = Mathf.Clamp(value, 0, MaxMp); OnMpChanged?.Invoke(); } }
    public float MaxHp { get => maxHp; set { maxHp = value; OnStatChanged?.Invoke(); } }
    public float MaxMp { get => maxMp; set { maxMp = value; OnStatChanged?.Invoke(); } }

    public float Power { get => power; set { power = value; OnStatChanged?.Invoke(); } }
    public float Critical { get => critical; set { critical = value; OnStatChanged?.Invoke(); } }
    public float Defence { get => defence; set { defence = value; OnStatChanged?.Invoke(); } }
    public float AttackSpeed { get => attackSpeed; set { attackSpeed = value; OnStatChanged?.Invoke(); } }
    public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; OnStatChanged?.Invoke(); } }

    public float Exp { get => exp; set { exp = Mathf.Clamp01(value); OnExpChanged?.Invoke(); } }
    public float Gold { get => gold; set { gold = value; OnStatChanged?.Invoke(); } }
    public int Level { get => level; set { level = value; OnStatChanged?.Invoke(); } }

    private void Awake() => Init();

    public void Init()
    {
        Level = 1;
        Exp = 0;
        Gold = 0;
        MaxHp = 500;
        MaxMp = 100;
        Power = 50;
        Critical = 10;
        Defence = 5;
        AttackSpeed = 5;
        MoveSpeed = 100;
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
    }
}