using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    [Header("[ Game Stat ]")]
    [SerializeField] private Image hpBar;
    [SerializeField] private TMP_Text hpValue;
    [SerializeField] private Image mpBar;
    [SerializeField] private TMP_Text mpValue;
    [SerializeField] private Image expBar;
    [SerializeField] private TMP_Text expValue;
    [SerializeField] private TMP_Text levelText;

    [Header("[ Inventory Stat ]")]
    [SerializeField] private TMP_Text powerText;
    [SerializeField] private TMP_Text criticalText;
    [SerializeField] private TMP_Text defenceText;
    [SerializeField] private TMP_Text attackSpeedText;
    [SerializeField] private TMP_Text moveSpeedText;

    private PlayerStatHandler stat;

    public void Init()
    {
        stat = GameManager.Instance.player.statHandler;
        stat.OnStatChanged += UpdateStats;
        stat.OnHpChanged += UpdateHP;
        stat.OnMpChanged += UpdateMP;
        stat.OnExpChanged += UpdateEXP;
        RefreshUI();
    }

    public void UpdateStats()
    {
        powerText.text = stat.Power.ToString("F0");
        criticalText.text = stat.Critical.ToString("F0");
        defenceText.text = stat.Defence.ToString("F0");
        attackSpeedText.text = stat.AttackSpeed.ToString("F1");
        moveSpeedText.text = stat.MoveSpeed.ToString("F1");

        hpBar.fillAmount = stat.CurrHp / stat.MaxHp;
        hpValue.text = $"{(int)stat.CurrHp} / {(int)stat.MaxHp}";

        mpBar.fillAmount = stat.CurrMp / stat.MaxMp;
        mpValue.text = $"{(int)stat.CurrMp} / {(int)stat.MaxMp}";

        levelText.text = $"Lv. {stat.Level}";
    }

    private void UpdateHP()
    {
        hpBar.fillAmount = stat.CurrHp / stat.MaxHp;
        hpValue.text = $"{(int)stat.CurrHp} / {(int)stat.MaxHp}";
    }

    private void UpdateMP()
    {
        mpBar.fillAmount = stat.CurrMp / stat.MaxMp;
        mpValue.text = $"{(int)stat.CurrMp} / {(int)stat.MaxMp}";
    }

    private void UpdateEXP()
    {
        expBar.fillAmount = stat.Exp;
        expValue.text = $"{(int)(stat.Exp)}%";
    }

    public void RefreshUI()
    {
        UpdateHP();
        UpdateMP();
        UpdateEXP();
        UpdateStats();
    }
}