using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Console.WriteLine("Added " + amount + " points to the Score");
    }

    public void SubtractScore(int amount)
    {
        score -= amount;
    }
}
