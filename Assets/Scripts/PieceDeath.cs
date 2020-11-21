using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDeath : MonoBehaviour
{
    public delegate void UnitDied(int score);
    public event UnitDied pieceDied;
    public bool kingPiece;
    public int scoreValue = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)//8 is the Death layer
        {
            Die(scoreValue);
        }
    }

    public void Die(int value)
    {
        if (pieceDied != null)
        {
            pieceDied(value);
            Debug.LogWarning("This Piece is dead!");
            if (kingPiece)
            {
                Debug.LogWarning("That was the King!");
            }
        }
    }


}
