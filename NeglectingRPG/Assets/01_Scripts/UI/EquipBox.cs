using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipBox : MonoBehaviour
{
    [SerializeField] private List<EquipSlot> equipSlot;

    public EquipSlot GetSlotByCategory(ITEM_CATEGORY category)
    {
        return equipSlot.Find(slot => slot.Category == category);
    }
    public bool TryEquip(ItemData item)
    {
        foreach (var slot in equipSlot)
        {
            if (!slot.CanEquip(item)) continue;

            // 교체가 일어나는 경우
            if (slot.CurrentItem != null)
            {
                // 기존 아이템 인벤토리로 복귀
                InventoryManager.Instance.AddItem(slot.CurrentItem);
            }

            // 새 아이템 장착
            slot.Init(item);
            return true;
        }

        return false;
    }
}
