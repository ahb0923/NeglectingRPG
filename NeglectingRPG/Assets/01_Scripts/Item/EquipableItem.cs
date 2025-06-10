using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : ItemData
{
    public int reinforceLevel;
    public bool isEquipped;

    public EquipableItem(ItemData_SO so) : base(so)
    {
        reinforceLevel = 0;
        isEquipped = false;
    }

}
