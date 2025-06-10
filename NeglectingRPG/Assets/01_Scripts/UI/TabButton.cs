using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    [SerializeField] private Transform normalImage;
    [SerializeField] private Transform highlightImage;
    [SerializeField] private Button button;

    public ITEM_CATEGORY type;

    public void Init()
    {
        if (button == null) return;
        if (normalImage == null) return;
        if (highlightImage == null) return;

        highlightImage.SetAsLastSibling();
    }

    public void OnFoucus(bool state)
    {
        highlightImage.gameObject.SetActive(state);
    }

    public void SetListener(Action<TabButton> action)
    {
        if (button != null)
            button.onClick.AddListener(() => { action(this); });
    }
}
