﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private DragIcon dragIcon;
    [SerializeField] private Transform inventory;
    [SerializeField] private Transform statusBox;
    [SerializeField] private Transform equipBox;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button closeInventoryButton;
    [SerializeField] private Button itemBoxButton;
    [SerializeField] private Button statusBoxButton;

    [SerializeField] public Animator dummyAnim;
    [SerializeField] public Transform itemBox; 
    [SerializeField] public Transform itemTextBox;
    [SerializeField] public UIPlayerInfo playerInfo;

    private void Start()
    {
        inventoryButton.onClick.AddListener(ShowInventory);
        closeInventoryButton.onClick.AddListener(CloseInventory);
        itemBoxButton.onClick.AddListener(ShowItemBox);
        statusBoxButton.onClick.AddListener(ShowStatusBox);

        playerInfo.Init();

        PlayerStatHandler statHandler = GameManager.Instance.player.statHandler;
        if (statHandler != null)
        {
            statHandler.OnStatChanged += () => playerInfo.UpdateStats();
        }


        StartCoroutine(C_SettinInitTab());
        CloseInventory();
    }

    IEnumerator C_SettinInitTab()
    {
        yield return null;
        itemBox.GetComponent<ItemBox>().Init();
    }
    public void ShowInventory()
    {
        if (inventory == null)
            return;
        if (!statusBox.gameObject.activeSelf)
        {
            statusBox.gameObject.SetActive(true);
        }
        inventory.gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        if (inventory == null)
            return;

        statusBox.gameObject.SetActive(true);
        itemBox.gameObject.SetActive(false);
        itemTextBox.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
    }

    public void ShowStatusBox()
    {
        statusBox.gameObject.SetActive(true);
        itemBox.gameObject.SetActive(false);
    }
    public void ShowItemBox()
    {
        statusBox.gameObject.SetActive(false);
        itemBox.gameObject.SetActive(true);
    }

    public void ShowDragIcon(Sprite sprite, Vector2 position)
    {
        dragIcon.SetIcon(sprite);
        dragIcon.SetPosition(position);
        dragIcon.Show();
    }

    public void UpdateDragIcon(Vector2 position)
    {
        dragIcon.SetPosition(position);
    }

    public void HideDragIcon()
    {
        dragIcon.Hide();
    }
}
