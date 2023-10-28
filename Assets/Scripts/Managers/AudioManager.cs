using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioManager", menuName = "ScriptableObjects/AudioManagerAsset")]
public class AudioManager : ScriptableObject
{
    public void PlayOneShot(AudioClip clip)
    {
        GameManager.instance.vfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        AudioSource source = GameManager.instance.musicSource;
        source.clip = clip;
        source.loop = true;
        GameManager.instance.musicSource.Play();
    }
}
