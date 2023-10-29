using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    private List<Environment> environmentsPool = new List<Environment>();
    private Environment lastEnvironment = null;
    public Transform startPoint;
    private float safeDistanceEnvironment = 1.2f;
    
    void Start()
    {
        SpawnEnvironment();
    }

    private void Update()
    {
        if (CheckIfNeedSpawnEnvironment())
        {
            SpawnEnvironment();
        }

        CleanEnvironments();
    }

    private bool CheckIfNeedSpawnEnvironment()
    {
        Player player = GameManager.instance.player;
        int lastIndex = environmentsPool.Count - 1;
        if(lastEnvironment == null)
        {
            Debug.Log("Last Environment null");
            return false;
        }
        if ((player.transform.position.x * safeDistanceEnvironment) > lastEnvironment.endPoint.position.x)
        {
            return true;
        }
        return false;
    }

    private void CleanEnvironments()
    {
        Player player = GameManager.instance.player;

        foreach (var environments in environmentsPool)
        {
            // * 1.2 Just to be on the safe side that won't disappear things that we are seeing yet
            if(player.transform.position.x > (environments.endPoint.position.x * safeDistanceEnvironment))
            {
                environments.Hide();
            }
        }
    }

    private void SpawnEnvironment()
    {
        if(environmentsPool.Count == 0) { 
            foreach (var environments in GameManager.instance.assets.environments)
            {
                if(lastEnvironment != null)
                {
                    lastEnvironment = Instantiate(environments).Show(lastEnvironment.endPoint);
                    environmentsPool.Add(lastEnvironment);
                    continue;
                }

                lastEnvironment = Instantiate(environments).Show(startPoint);
                environmentsPool.Add(lastEnvironment);
            }
            return;
        }
        
        lastEnvironment = GetFirstFreeEnvironment().Show(lastEnvironment.endPoint);
    }

    private Environment GetFirstFreeEnvironment()
    {
        foreach (var environment in environmentsPool)
        {
            if(environment.isFree) {
                return environment;
            }
        }

        Debug.LogError("Don't have environment free to use");
        return null;
    }
}
