using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private int minSlotCount = 20;
    [SerializeField] private GridLayoutGroup gridLayout;

    private TabTitle tabTitle;
    private ITEM_TYPE currTab = (ITEM_TYPE)(-1);


    private List<ItemSlot> slotList = new();

    public void Init()
    {
        Debug.Log("초기화 진행되는거맞음?");
        tabTitle = GetComponentInChildren<TabTitle>(true);
        if (tabTitle != null)
        {
            tabTitle.Init();
            tabTitle.SetListener(OnClickTab);
        }

        ItemSlotPool.Instance.InitPool(minSlotCount);
        SetTab(ITEM_TYPE.ALL);
    }

    public void OnClickTab(TabButton button)
    {
        SetTab(button.type);
    }

    public void SetTab(ITEM_TYPE category)
    {
        if (currTab == category)
            return;

        currTab = category;
        tabTitle.SetTab(currTab);

        ItemSlotPool.Instance.ReturnAll(slotList);

        var items = ItemManager.Instance.GetItemsByType(currTab);

        foreach (var item in items)
        {
            var slot = ItemSlotPool.Instance.GetSlot();
            slot.transform.SetParent(gridLayout.transform, false);
            slot.Init(item);
            slotList.Add(slot);
        }
        while (slotList.Count < minSlotCount)
        {
            var emptySlot = ItemSlotPool.Instance.GetSlot();
            emptySlot.transform.SetParent(gridLayout.transform, false);
            emptySlot.Init(null); // 빈 슬롯
            slotList.Add(emptySlot);
        }
    }
}
