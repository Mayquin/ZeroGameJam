using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public LaunchManager launchManager;
    public ShopManager shopManager;
    public EndGameUI endGame;

    public void Start()
    {
        GameManager.instance.uiManager = this;
    }

    public void ShowShop()
    {
        launchManager.gameObject.SetActive(false);
        shopManager.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
    }
    public void ShowEndGame()
    {
        launchManager.gameObject.SetActive(false);
        shopManager.gameObject.SetActive(false);
        endGame.gameObject.SetActive(true);
    }
    public void ShowLaunch()
    {
        launchManager.gameObject.SetActive(true);
        shopManager.gameObject.SetActive(false);
        endGame.gameObject.SetActive(false);
    }
}
