using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public enum ITEM_TYPE
{
    ALL,
    WEAPON,
    ARMOR,
    BOOTS,
    ARTIFACT
}

[CreateAssetMenu(fileName = "NewItemData", menuName = "Item Data")]
public class ItemData_SO : ScriptableObject
{
    [Header("[ Defalut Data ]")]
    public ITEM_TYPE type;
    public int code;
    public string itemName;
    public int price;
    public bool isStack;

    [Header("[ Status Data ]")]
    public float maxHp;
    public float maxMp;
    public float power;
    public float critical;
    public float defence;
    public float attackSpeed;
    public float moveSpeed;

    [Header("[ Image Data ]")]
    public Sprite icon;
}
