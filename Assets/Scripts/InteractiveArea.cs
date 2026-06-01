using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    private int score = 0;

    public int AgregarPunto()
    {
        score++;
        Debug.Log("Score: " + score);
        return score;
    }
}