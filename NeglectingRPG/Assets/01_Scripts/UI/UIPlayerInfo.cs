using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private Image icon;


    [Header("HP")]
    [SerializeField] private Image hpBar;
    [SerializeField] private TMP_Text hpValue;

    [Header("MP")]
    [SerializeField] private Image mpBar;
    [SerializeField] private TMP_Text mpValue;

    [Header("EXP")]
    [SerializeField] private Image expBar;
    [SerializeField] private TMP_Text expValue;

    [Header("레벨")]
    [SerializeField] private TMP_Text levelText;

    private PlayerStatHandler stat;

    public void Init()
    {
        stat = GameManager.Instance.player.GetComponent<PlayerStatHandler>();
        RefreshUI();
    }

    public void RefreshUI()
    {
        hpBar.fillAmount = stat.CurrHp / stat.MaxHp;
        hpValue.text = $"{(int)stat.CurrHp} / {(int)stat.MaxHp}";

        mpBar.fillAmount = stat.CurrMp / stat.MaxMp;
        mpValue.text = $"{(int)stat.CurrMp} / {(int)stat.MaxMp}";

        expBar.fillAmount = stat.Exp;
        expValue.text = $"{(int)(stat.Exp * 100)}%"; 

        levelText.text = $"Lv. {stat.Level}";
    }
}
