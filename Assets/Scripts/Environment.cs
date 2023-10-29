using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Transform endPoint;
    [HideInInspector]
    public bool isActive = false;
    [HideInInspector]
    public bool isFree = false;
    [HideInInspector]
    public Transform mTransform = null;
    public Transform pumpkinSpawnerTransform;


    public Environment Hide()
    {
        gameObject.SetActive(false);
        isFree = true;
        isActive = false;
        return this;
    }

    public Environment Show(Transform targetPosition)
    {
        if(mTransform == null) mTransform = transform;
        mTransform.position = targetPosition.position;
        SetupEnvironment();
        gameObject.SetActive(true);
        isFree = false;
        isActive = true;
        return this;
    }

    public void SetupEnvironment()
    {
        Player player = GameManager.instance.player;
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            if (player.skills[(int)SKILLS.GOLDENPUMPKINS] == 0)
            {
                var pumpkin = GameManager.instance.environmentManager.GetFirstFreePumpkin();
                
                if(pumpkin == null )
                {
                    Instantiate(GameManager.instance.assets.pumpkinPrefab[0], new Vector3(pumpkinSpawnerTransform.position.x, 0.5f, 0), pumpkinSpawnerTransform.rotation);
                    return;
                }

                pumpkin.Show(pumpkinSpawnerTransform);
            }
        }
    }
}
