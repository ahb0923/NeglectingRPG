using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    private static int globalIdCounter = 0;
    public int uniqueId;
    public ItemData_SO baseData;

    public ItemData(ItemData_SO so)
    {
        baseData = so;
        uniqueId = globalIdCounter++;
    }
}
