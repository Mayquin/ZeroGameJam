using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioManager", menuName = "ScriptableObjects/AudioManagerAsset")]
public class AudioManager : ScriptableObject
{
    public void PlayOneShot(AudioClip clip)
    {
        GameManager.instance.audioSource.PlayOneShot(clip);
    }
}
