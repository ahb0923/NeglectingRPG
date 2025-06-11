using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ITEM_CATEGORY category;
    public Image iconImage;
    public Image backGroundImage;
    public ItemData CurrentItem { get; set; }
    public ITEM_CATEGORY Category => category;

    public bool CanEquip(ItemData item)
    {
        return item.baseData.category == Category;
    }
    private void Awake()
    {
        Clear();
    }
    public void Init(ItemData data)
    {
        CurrentItem = data;
        if (CurrentItem != null)
        {
            iconImage.sprite = data.baseData.icon;
            iconImage.enabled = true;
            gameObject.SetActive(true);
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
            gameObject.SetActive(true);
        }
        transform.localScale = Vector3.one;
    }

    public void Clear()
    {
        CurrentItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        var draggedSlot = eventData.pointerDrag?.GetComponent<ItemSlot>();
        if (draggedSlot == null || draggedSlot.CurrentItem == null) return;

        // 아이템 종류에 맞는지 체크
        if (CanEquip(draggedSlot.CurrentItem)) 
        {
            // 기존 아이템이 있다면 되돌리기
            if (CurrentItem != null)
            {
                InventoryManager.Instance.AddItem(CurrentItem);
                UIManager.Instance.itemBox.GetComponent<ItemBox>().UpdateBox(ITEM_CATEGORY.ALL); // 인벤토리 새로고침
            }

            // 장착(메소드로 추후 따로 만들 것)
            CurrentItem = draggedSlot.CurrentItem;
            iconImage.sprite = CurrentItem.baseData.icon;
            iconImage.enabled = true;
            UIManager.Instance.dummyAnim.SetTrigger("Equip");
            GameManager.Instance.player.statHandler.ApplyModifier(CurrentItem);

            // 인벤토리에서 제거
            InventoryManager.Instance.RemoveItemById(draggedSlot.CurrentItem.uniqueId);
            draggedSlot.Init(null); // 원래 인벤토리 칸 비우기
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && CurrentItem != null)
        {
            Debug.Log($"[{category}] 해제: {CurrentItem.baseData.itemName}");

            GameManager.Instance.player.statHandler.RemoveModifier(CurrentItem);
            InventoryManager.Instance.AddItem(CurrentItem);
            UIManager.Instance.itemBox.GetComponent<ItemBox>().UpdateBox(CurrentItem.baseData.category); // 인벤토리 새로고침
          
            Clear(); // 장비칸 비우기
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (CurrentItem == null) return;
        UIManager.Instance.itemTextBox.gameObject.SetActive(true);
        UIManager.Instance.itemTextBox.GetComponent<ItemTextBox>().SetText(CurrentItem);

        if (backGroundImage == null) return;
        var color = backGroundImage.color;
        color.r = 0.5f;
        color.b = 0.5f;
        backGroundImage.color = color;
    }
    // 아이템 정보 끄기
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.itemTextBox.gameObject.SetActive(false);
        if (backGroundImage == null) return;
        var color = backGroundImage.color;
        color.r = 1f;
        color.b = 1f;
        backGroundImage.color = color;

    }
}
