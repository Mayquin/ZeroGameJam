using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillsData
{
    public Sprite icon;
    public int price;
    public string title;
    [TextArea(2, 5)]
    public string description;
    public SKILLS skill;
}
