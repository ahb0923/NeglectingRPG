using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup gridLayout;

    private TabTitle tabTitle;

    private ITEM_CATEGORY currTab = (ITEM_CATEGORY)(-1);
    public ITEM_CATEGORY CurrTab => currTab;

    private List<ItemSlot> slotList = new();

    public void Init()
    {
        tabTitle = GetComponentInChildren<TabTitle>(true);
        if (tabTitle != null)
        {
            tabTitle.Init();
            tabTitle.SetListener(OnClickTab);
        }

        ItemSlotPool.Instance.InitPool(InventoryManager.Instance.MinSlotCount);
        SetTab(ITEM_CATEGORY.ALL);
    }

    public void OnClickTab(TabButton button)
    {
        SetTab(button.type);
    }

    public void SetTab(ITEM_CATEGORY category)
    {
        if (currTab == category)
            return;

        currTab = category;
        tabTitle.SetTab(currTab);

        DrawItem();
    }

    public void UpdateBox(ITEM_CATEGORY category)
    {
        if (currTab == category || currTab == ITEM_CATEGORY.ALL)
        {
            Debug.Log("UpdateBox 실행");
            DrawItem();
        }
    }

    public void DrawItem()
    {
        ItemSlotPool.Instance.ReturnAll(slotList);
        slotList.Clear();

        var items = InventoryManager.Instance.GetItemsByCategory(currTab);
        int itemCount = items.Count;
        //Debug.Log(itemCount);

        // 아이템 카테고리가 ALL 이라면 최소 12칸 확보, 아이템의 위치 기억
        if (currTab == ITEM_CATEGORY.ALL)
        {
            int totalSlotCount = Mathf.Max(itemCount, InventoryManager.Instance.MinSlotCount);

            for (int i = 0; i < totalSlotCount; i++)
            {
                var slot = ItemSlotPool.Instance.GetSlot();
                slot.transform.SetParent(gridLayout.transform, false);

                if (i < itemCount)
                {
                    slot.Init(items[i]);
                }
                else
                {
                    slot.Init(null);
                }
                slot.SlotIndex = i;
                slotList.Add(slot);
            }
        }
        else
        {
            foreach (var item in items)
            {
                var slot = ItemSlotPool.Instance.GetSlot();
                slot.transform.SetParent(gridLayout.transform, false);
                slot.Init(item);
                slotList.Add(slot);
            }
        }

        // => 추가 학습 필요
        LayoutRebuilder.ForceRebuildLayoutImmediate(gridLayout.GetComponent<RectTransform>());
    }
}

