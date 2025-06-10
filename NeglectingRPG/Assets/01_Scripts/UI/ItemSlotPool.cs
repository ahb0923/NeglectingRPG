using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotPool : Singleton<ItemSlotPool>
{
    [SerializeField] private ItemSlot slotPrefab;
    [SerializeField] private Transform poolParent;

    private Queue<ItemSlot> pool = new();

    public void InitPool(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var slot = Instantiate(slotPrefab, poolParent);
            slot.gameObject.SetActive(false);
            pool.Enqueue(slot);
        }
    }

    public ItemSlot GetSlot()
    {
        if(pool.Count > 0)
        {
            var slot = pool.Dequeue();
            slot.gameObject.SetActive(true);
            return slot;
        }
        else
        {
            var slot = Instantiate(slotPrefab, poolParent);
            return slot;
        }
    }
    public void ReturnSlot(ItemSlot slot)
    {
        slot.Clear();
        slot.transform.SetParent(poolParent);
        pool.Enqueue(slot);
    }
    
    public void ReturnAll(List<ItemSlot> slotList)
    {
        foreach (var slot in slotList)
        {
            ReturnSlot(slot);
        }
        slotList.Clear();
    }
}
