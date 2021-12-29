using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public void DestroyLight()
    {
        gameObject.SetActive(false);
        LightSpawner.Instance.AddLightToQueue(gameObject);
    }
}
