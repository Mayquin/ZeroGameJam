using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameAssets", menuName = "ScriptableObjects/GameAssets")]
public class GameAssets : ScriptableObject
{
    [SerializeField]
    public SerializedDictionary<string, AudioClip> audioAssets = new SerializedDictionary<string, AudioClip>();
    [SerializeField]
    public List<Environment> environments = new List<Environment>();
    [SerializeField]
    public Skills skills;
    [SerializeField]
    public List<GameObject> pumpkinPrefab = new List<GameObject>();
    [SerializeField]
    public SerializedDictionary<ANIMATIONS, string> animations = new SerializedDictionary<ANIMATIONS, string>();
}
