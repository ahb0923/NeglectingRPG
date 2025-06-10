using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabTitle : MonoBehaviour
{
    private List<TabButton> tabButtons = new();

    public void Init()
    {
        tabButtons.AddRange(GetComponentsInChildren<TabButton>(true));
        foreach (var buttons in tabButtons)
            buttons.Init();
    }
    
    public void SetListener(System.Action<TabButton> action)
    {
        foreach (var button in tabButtons)
            button.SetListener(action);
    }

    public void SetTab(ITEM_TYPE catecory)
    {
        foreach (var button in tabButtons)
        {
            if(button.type == catecory)
            {
                button.OnFoucus(true);
            }
            else button.OnFoucus(false);
        }
    }
}
