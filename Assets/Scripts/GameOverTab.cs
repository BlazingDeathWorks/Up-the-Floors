using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTab : MonoBehaviour
{
    [SerializeField] GameObject tab = null;

    private void Awake()
    {
        Light.LightLifeFinished += () =>
        {
            if (tab == null) return;
            tab.SetActive(true);
        };
        tab.SetActive(false);
    }
}
