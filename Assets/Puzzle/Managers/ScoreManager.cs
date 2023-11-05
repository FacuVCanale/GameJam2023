using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    
    public static void ResetScore() {
        score = 0;
    }

    public static void SumLevelScore(int levelScore) {
        score += levelScore;
    }

    public static void AverageScore(int levels) {
        score = score / levels;
    }

    public static int GetScore() {
        return score;
        Debug.Log("Score: " + score);
    }
}
