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
    private float originalTimeBeforeNextEnded;

    private void Awake()
    {
        originalTimeBeforeNextEnded = ++timeBeforeNextEnded;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeNextEnded -= Time.deltaTime;
        if (timeBeforeNextEnded <= 1)
        {
            TimerEnded?.Invoke();
            timeBeforeNextEnded = originalTimeBeforeNextEnded;
        }
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = ((int)timeBeforeNextEnded).ToString();
    }
}
