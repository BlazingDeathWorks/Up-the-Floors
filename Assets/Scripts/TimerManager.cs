using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    public static event Action TimerEnded = null;
    [SerializeField] private TMP_Text text = null;
    [SerializeField] private float timeBeforeNextEnded;
    private float scale = 1, scaleIncreaseRate = 0.1f;
    private float originalTimeBeforeNextEnded;

    private void Awake()
    {
        Time.timeScale = 1;
        originalTimeBeforeNextEnded = ++timeBeforeNextEnded;
        UpdateText();
        Light.LightLifeFinished += StopTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeNextEnded -= Time.deltaTime * scale;
        if (timeBeforeNextEnded <= 1)
        {
            TimerEnded?.Invoke();
            timeBeforeNextEnded = originalTimeBeforeNextEnded;
        }
        UpdateText();

        //Update Scale
        scale += Time.deltaTime * scaleIncreaseRate;
        if (scale >= originalTimeBeforeNextEnded) scale = 1;
    }

    private void UpdateText()
    {
        text.text = ((int)timeBeforeNextEnded).ToString();
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }
}
