using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameAssets assets;
    public AudioManager audioManager;
    public AudioSource vfxSource;
    public AudioSource musicSource;
    [HideInInspector]
    public Camera mainCamera;
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public GAMEMODE gameMode = GAMEMODE.IDLE;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            InitStuffs();
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    private void InitStuffs()
    {
        audioManager.PlayMusic(assets.audioAssets["music"]);
    }
}
