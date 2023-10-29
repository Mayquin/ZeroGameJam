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
    public GenerateEnvironment environmentManager;
    [HideInInspector]
    public Camera mainCamera;
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public GAMEMODE gameMode = GAMEMODE.IDLE;
    [HideInInspector]
    public UIManager uiManager;
    [HideInInspector]
    public MatchRecorder matchRecorder;

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
        audioManager.PlayMusic(assets.audioAssets[AUDIOS.MUSIC]);
    }

    public IEnumerator EndGame()
    {
        gameMode = GAMEMODE.END;
        yield return new WaitForSeconds(1.5f);
        uiManager.ShowEndGame();
    }
}
