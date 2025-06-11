using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private int minSlotCount = 12;
    public int MinSlotCount => minSlotCount;
    // 슬롯 순서가 유지되는 리스트 => ALL 탭 전용
    [SerializeField] private List<ItemData> slotList = new();
    protected override void Awake()
    {
        base.Awake();
        // 최소 슬롯 수만큼 null로 초기화
        while (slotList.Count < minSlotCount)
            slotList.Add(null);
    }

    private void Start()
    {
        for(int i = 0; i < 10; i++)
            GenerateRandomItems();
    }
    // 아이템 추가
    public void AddItem(ItemData item)
    {
        int index = slotList.FindIndex(x => x == null);
        if (index >= 0) 
        { 
            Debug.Log($"비어있는 index : {index}");
            slotList[index] = item;
            Debug.Log($"슬롯{slotList[index].baseData.itemName} ");
        }
        else
            slotList.Add(item);
    }
    
    public void SwapSlotPosition(int from, int to)
    {
        // 방어코드
        if (from < 0 || from >= slotList.Count || to < 0 || to >= slotList.Count) return;

        var temp = slotList[from];
        slotList[from] = slotList[to];
        slotList[to] = temp;

        //DebugPrintSlotList();
    }

    // 아이템 제거
    public void RemoveItem(int index)
    {
        if (index < 0 || index >= slotList.Count) return;
        slotList[index] = null;
    }
    public void RemoveItemById(int uniqueId)
    {
        int index = slotList.FindIndex(x => x != null && x.uniqueId == uniqueId);
        if (index >= 0) slotList[index] = null;
    }

    // 해당되는 카테고리의 아이템만 담은 리스트 리턴
    public List<ItemData> GetItemsByCategory(ITEM_CATEGORY category)
    {
        // ALL 탭은 아이템 위치를 원하는대로 커스텀 가능
        if (category == ITEM_CATEGORY.ALL)
            return slotList;

        // 이외의 탭은 ID 오름차순으로 자동 정렬 (위치변경은 가능하지만 저장은 X)
        return slotList
            .Where(i => i != null && i.baseData.category == category)
            .OrderBy(i => i.uniqueId)
            .ToList();
    }


    // 몬스터의 랜덤 드랍 혹은 상점에서 아이템을 구매할 시 해당 코드 재활용
    [ContextMenu("Generate Random Items")]
    public void GenerateRandomItems()
    {
        ItemData generateItem = new ItemData(ItemManager.Instance.GetRandomItems());
        AddItem(generateItem);
        UIManager.Instance.itemBox.GetComponent<ItemBox>().UpdateBox(generateItem.baseData.category);
        Debug.Log($"아이템 생성 : {generateItem.uniqueId} / {generateItem.baseData.itemName}");
        
    }
    
    // 슬롯 체크용 
    public void DebugPrintSlotList()
    {
        Debug.Log("=== 인벤토리 순서 ===");
        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i]==null) Debug.Log($"{i}: Null!");
            else Debug.Log($"{i}: {slotList[i].baseData.itemName}");
        }
           
    }

}
