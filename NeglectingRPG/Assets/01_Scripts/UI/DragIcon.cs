using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragIcon : MonoBehaviour
{
    public Image iconImage;
    private RectTransform rect;

    private void Awake()
    {
        if (iconImage == null)
           iconImage = GetComponent<Image>();

        rect = GetComponent<RectTransform>();
        Hide();
    }

    public void SetIcon(Sprite sprite)
    {
        iconImage.sprite = sprite;
    }

    public void SetPosition(Vector2 screenPos)
    {
        rect.position = screenPos;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
