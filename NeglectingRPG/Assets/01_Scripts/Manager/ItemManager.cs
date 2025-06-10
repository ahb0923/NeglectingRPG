using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_CATEGORY
{
    ALL,
    WEAPON,
    ARMOR,
    BOOTS,
    ARTIFACT
}
public enum ITEM_TYPE
{
    EQUIPABLE,
    CONSUMABLE
}

public class ItemManager : Singleton<ItemManager>
{
    public List<ItemData_SO> allItems;

    private Dictionary<ITEM_CATEGORY, List<ItemData_SO>> categorizedItems;

    protected override void Awake()
    {
        base.Awake();
        categorizedItems = new();
        foreach (ITEM_CATEGORY type in Enum.GetValues(typeof(ITEM_CATEGORY)))
        {
            categorizedItems[type] = new List<ItemData_SO>();
        }
        foreach (var item in allItems)
        {
            categorizedItems[item.category].Add(item);
        }
    }

    public List<ItemData_SO> GetItemsByCategory(ITEM_CATEGORY type)
    {
        if (type == ITEM_CATEGORY.ALL)
            return allItems;

        return categorizedItems[type];
    }

    public ItemData_SO GetRandomItems()
    {
        if (allItems == null || allItems.Count == 0)
            return null;

        int index = UnityEngine.Random.Range(0, allItems.Count);
        return allItems[index];
    }

}
