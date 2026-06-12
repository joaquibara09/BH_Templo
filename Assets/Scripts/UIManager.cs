// UIManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelGameOver;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtPuntaje;

    void Start()
    {
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
    }

    public void UpdateScore(int score, int max)
    {
        txtPuntaje.text = "Puntaje: " + score + "/" + max;
    }

    public void UpdateTimer(float tiempo)
    {
        txtTimer.text = "Tiempo: " + Mathf.CeilToInt(tiempo);
    }

    public void MostrarPantallaWin()
    {
        panelWin.SetActive(true);
    }

    public void MostrarPantallaGameOver()
    {
        panelGameOver.SetActive(true);
    }
}
