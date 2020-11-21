using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour
{
    public delegate void UnitDied(int score);
    public static event UnitDied PieceDied;

    public Text scoreText;
    private int score = 0;

    private void OnEnable()
    {
        var Objects = FindObjectsOfType<PieceDeath>();
        foreach(PieceDeath piece in Objects)
        {
            piece.pieceDied += UpdateScore;
        }
    }

    private void OnDisable()
    {
        var Objects = FindObjectsOfType<PieceDeath>();
        foreach (PieceDeath piece in Objects)
        {
            piece.pieceDied -= UpdateScore;
        }
    }

    public void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}
