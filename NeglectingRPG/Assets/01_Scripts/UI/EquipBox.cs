using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipBox : MonoBehaviour
{
    [SerializeField] private List<EquipSlot> equipSlot;

    // Start is called before the first frame update
    public EquipSlot GetSlotByCategory(ITEM_CATEGORY category)
    {
        return equipSlot.Find(slot => slot.Category == category);
    }
    public bool TryEquip(ItemData item)
    {
        foreach (var slot in equipSlot)
        {
            if (!slot.CanEquip(item)) continue;

            // 이미 장착 중이라면 기존 장비를 인벤토리로 되돌림
            if (slot.CurrentItem != null)
            {
                InventoryManager.Instance.AddItem(slot.CurrentItem);
            }

            slot.Init(item); // 새 장비 장착
            return true;
        }

        return false;
    }
}
