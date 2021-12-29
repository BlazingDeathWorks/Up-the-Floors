using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Light : MonoBehaviour
{
    public static event Action LightLifeFinished;
    private float timeSinceCreated = 0, lifeRate = 1f;

    private void OnEnable()
    {
        timeSinceCreated = 0;
    }

    private void Update()
    {
        timeSinceCreated += Time.deltaTime;
        if(timeSinceCreated >= lifeRate)
        {
            LightLifeFinished?.Invoke();
        }
    }

    public void ReQueueLight()
    {
        gameObject.SetActive(false);
        LightSpawner.Instance.AddLightToQueue(gameObject);
    }
}
