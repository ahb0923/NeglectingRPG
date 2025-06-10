using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public int uniqueId;
    public ItemData_SO baseData;

    public ItemData(ItemData_SO so)
    {
        baseData = so;
        uniqueId = so.code;
    }
}
