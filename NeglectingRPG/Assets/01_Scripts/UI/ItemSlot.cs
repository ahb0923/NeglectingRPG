using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    public Image iconImage;
    public ItemData_SO CurrentItem { get; set; }

    private Transform originalParent;

    public void Init(ItemData_SO data)
    {
        CurrentItem = data;
        if (CurrentItem != null)
        {
            iconImage.sprite = data.icon;
            iconImage.enabled = true;
            gameObject.SetActive(true);
        }
        else Clear();
        transform.localScale = Vector3.one;
    }

    public void Clear()
    {
        CurrentItem = null;
        iconImage.sprite = null;  
        iconImage.enabled = false;
        gameObject.SetActive(false);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentItem != null) return;

        UIManager.Instance.ShowDragIcon(CurrentItem.icon, eventData.position);
        originalParent = transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CurrentItem != null) return;
        UIManager.Instance.UpdateDragIcon(eventData.position);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        UIManager.Instance.HideDragIcon();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedSlot = eventData.pointerDrag?.GetComponent<ItemSlot>();

        // 자기 자신 위치거나 엉뚱한곳에 떨궜거나
        if (draggedSlot == null || draggedSlot == this) return;

        // 장비칸에 떨궜을 경우 장착 로직 호출
            // 장비칸이 비었을경우 & 장비칸에 이미 아이템 장착중일 경우 분기
        


        SwapItems(draggedSlot);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && CurrentItem != null)
        {
            Debug.Log($"장착: {CurrentItem.itemName}");
            // 장착 로직 호출
        }
    }
    private void SwapItems(ItemSlot other)
    {
        var temp = other.CurrentItem;
        other.Init(CurrentItem);
        Init(temp);
    }

    public void RefreshUI()
    {
        if (CurrentItem != null)
        {
            iconImage.sprite = CurrentItem.icon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
    }
}
