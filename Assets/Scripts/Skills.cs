using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills")]
public class Skills : ScriptableObject
{
    [SerializeField]
    public List<SkillsData> skills = new List<SkillsData>();
}
