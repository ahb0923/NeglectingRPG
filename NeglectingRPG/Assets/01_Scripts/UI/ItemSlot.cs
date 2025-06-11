using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 현재 슬롯에 들어있는 아이템에 대한 정보
    public ItemData CurrentItem { get; set; }

    // 현재 아이콘 이미지 (DragImage 복사용)
    public Image iconImage;
    public Image backGroundImage;

    // 아이콘 인덱스
    public int SlotIndex { get; set; }

    private Transform originalParent;

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

    public virtual void Clear()
    {
        CurrentItem = null;
        iconImage.sprite = null;  
        iconImage.enabled = false;
        gameObject.SetActive(false);
    }
    // 드래그 시작시 투명도 낮추기
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentItem == null) return;
        UIManager.Instance.ShowDragIcon(CurrentItem.baseData.icon, eventData.position);
        var color = iconImage.color;
        color.a = 0.5f;
        iconImage.color = color;
        originalParent = transform;
    }
    // 드래그 도중 DragImage 포인터 따라가게 하기
    public virtual void OnDrag(PointerEventData eventData)
    {
        UIManager.Instance.UpdateDragIcon(eventData.position);
    }

    // 드래그 끝날시 투명도 복원
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        UIManager.Instance.HideDragIcon();
        var color = iconImage.color;
        color.a = 1f;
        iconImage.color = color;
    }

    // 
    public virtual void OnDrop(PointerEventData eventData)
    {
        var draggedSlot = eventData.pointerDrag?.GetComponent<ItemSlot>();
        if (draggedSlot == null)
        {
            Debug.Log($" 아이템 slot 이외 클릭 : {draggedSlot}");
            return;
        }

        SwapItems(draggedSlot);
        UIManager.Instance.itemTextBox.gameObject.SetActive(false);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        // 우클릭시 장착
        if (CurrentItem != null && eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log($"장착: {CurrentItem.baseData.itemName}");
            // 장착 로직 호출
           // UIManager.Instance.
        }
        // 좌클릭 시 (현재 기능 없음 추후 추가 예정)
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(CurrentItem!=null)
                Debug.Log($"슬롯 인덱스 : {SlotIndex} / {CurrentItem.baseData.itemName}");
        }
    }
    // 아이템 정보 띄우기
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

    private void SwapItems(ItemSlot other)
    {
        if (other.CurrentItem == null) return;
        if (SlotIndex < 0 || other.SlotIndex < 0) return;

        var temp = other.CurrentItem;
        other.Init(CurrentItem);
        Init(temp);

        if (UIManager.Instance.itemBox.GetComponent<ItemBox>().CurrTab == ITEM_CATEGORY.ALL)
        {
            InventoryManager.Instance.SwapSlotPosition(SlotIndex, other.SlotIndex);
            UIManager.Instance.itemBox.GetComponent<ItemBox>().DrawItem();
        }
    }

    public void RefreshUI()
    {
        if (CurrentItem != null)
        {
            iconImage.sprite = CurrentItem.baseData.icon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
    }
}
