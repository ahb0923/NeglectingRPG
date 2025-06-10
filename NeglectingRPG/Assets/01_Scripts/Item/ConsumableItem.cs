using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : ItemData
{
    public int maxStack;
    public int currentStack;

    public ConsumableItem(ItemData_SO so) : base(so)
    {
        currentStack = 1;
    }

    public void Use()
    {
        currentStack--;
    }
}
