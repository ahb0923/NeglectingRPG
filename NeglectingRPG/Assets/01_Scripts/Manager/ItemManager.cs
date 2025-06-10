using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public List<ItemData_SO> allItems;

    private Dictionary<ITEM_TYPE, List<ItemData_SO>> categorizedItems;

    private void Awake()
    {
        base.Awake();
        categorizedItems = new();
        foreach (ITEM_TYPE type in Enum.GetValues(typeof(ITEM_TYPE)))
        {
            categorizedItems[type] = new List<ItemData_SO>();
        }
        foreach (var item in allItems)
        {
            categorizedItems[item.type].Add(item);
        }
    }

    public List<ItemData_SO> GetItemsByType(ITEM_TYPE type)
    {
        if (type == ITEM_TYPE.ALL)
            return allItems;

        return categorizedItems[type];
    }
}
