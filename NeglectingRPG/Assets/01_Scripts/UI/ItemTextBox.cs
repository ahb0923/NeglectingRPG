using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI valueText;


    public void SetText(ItemData item)
    {
        if (item == null) return;
        nameText.text = item.baseData.name;
        valueText.text = $"{item.baseData.power}\n{item.baseData.critical}\n{item.baseData.defence}\n{item.baseData.attackSpeed}\n{item.baseData.moveSpeed}\n{item.baseData.maxHp}\n{item.baseData.maxMp}";
    }
}
