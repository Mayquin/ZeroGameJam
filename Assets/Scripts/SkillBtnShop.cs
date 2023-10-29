using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtnShop : MonoBehaviour
{
    public Button btnShop;
    private SkillsData mSkill;

    public void SetupButton(SkillsData skill)
    {
        btnShop.image.sprite = skill.icon;
        btnShop.onClick.AddListener(() => GameManager.instance.shopManager.SetupBuyInfo(skill));
    }
}
