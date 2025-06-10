using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : ItemSlot
{
    [SerializeField] private ITEM_CATEGORY category;
    public ITEM_CATEGORY Category => category;

    public bool CanEquip(ItemData item)
    {
        // 예시: 해당 슬롯이 받아들일 수 있는 장비 타입인지 확인
        return item.baseData.category == Category;
    }
    private void Awake()
    {
        Clear();
    }
    public override void Clear()
    {
        CurrentItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
    }
    public override void OnDrop(PointerEventData eventData)
    {
        var draggedSlot = eventData.pointerDrag?.GetComponent<ItemSlot>();
        if (draggedSlot == null || draggedSlot.CurrentItem == null) return;

        // 아이템 종류에 맞는지 체크
        if (CanEquip(draggedSlot.CurrentItem)) 
        {
            // 기존 아이템이 있다면 되돌리기
            if (CurrentItem != null)
                InventoryManager.Instance.AddItem(CurrentItem);

            // 장착
            CurrentItem = draggedSlot.CurrentItem;
            iconImage.sprite = CurrentItem.baseData.icon;
            iconImage.enabled = true;

            // 인벤토리에서 제거
            InventoryManager.Instance.RemoveItem(draggedSlot.SlotIndex);
            draggedSlot.Init(null); // 원래 인벤토리 칸 비우기
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        return;
    }
    // 드래그 도중 DragImage 포인터 따라가게 하기
    public override void OnDrag(PointerEventData eventData)
    {
        return;
    }

    // 드래그 끝날시 투명도 복원
    public override void OnEndDrag(PointerEventData eventData)
    {
        return;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && CurrentItem != null)
        {
            Debug.Log($"[{category}] 해제: {CurrentItem.baseData.itemName}");
            Clear(); // 장비칸 비우기
            UIManager.Instance.itemBox.GetComponent<ItemBox>().UpdateBox(ITEM_CATEGORY.ALL); // 인벤토리 새로고침
            InventoryManager.Instance.AddItem(CurrentItem);
        }
    }
}
