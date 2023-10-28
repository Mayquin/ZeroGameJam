using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public AudioManager audioManager;
    public AudioSource vfxSource;
    public AudioSource musicSource;
    public GameAssets assets;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
