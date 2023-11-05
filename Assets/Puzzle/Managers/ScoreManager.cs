using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    
    public void SumLevelScore(int levelScore) {
        score += levelScore;
    }

    public void AverageScore(int levels) {
        score = score / levels;
    }

    public int GetScore() {
        return score;
        Debug.Log("Score: " + score);
    }
}
