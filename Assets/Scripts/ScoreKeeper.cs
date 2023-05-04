using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score += score;
        PlayerPrefs.SetInt("Score", this.score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
