using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public RectTransform holderBtnSkills;
    public GameObject prefab;

    // Skill Box
    [Header("Skill Box")]
    public Image icon;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Button buyButton;

    private void Start()
    {
        GameManager.instance.shopManager = this;
        SetupShop();
    }

    void SetupShop()
    {
        Skills skills = GameManager.instance.assets.skills;

        foreach (var skill in skills.skills)
        {
            Instantiate(prefab, holderBtnSkills).GetComponent<SkillBtnShop>().SetupButton(skill);
        }
    }

    public void SetupBuyInfo(SkillsData skill)
    {
        icon.sprite = skill.icon;
        title.text = skill.title;
        description.text = skill.description;
        buyButton.onClick.AddListener(() => GetSkill(skill));
    }

    public void GetSkill(SkillsData skill)
    {
        GameManager.instance.player.skills[(int)skill.skill]++;
    }
}
