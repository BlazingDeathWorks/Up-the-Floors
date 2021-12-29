using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text = null;
    private int score = 0;
    private const int INCREMENT_BY = 10;

    private void Awake()
    {
        UpdateScore();
    }

    public void IncrementScore()
    {
        score += INCREMENT_BY;
        UpdateScore();
    }

    private void UpdateScore()
    {
        text.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }
}
