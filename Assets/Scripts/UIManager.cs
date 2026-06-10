// UIManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject goCartelPresione;
    public GameObject panelWin;
    public GameObject panelGameOver;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtPuntaje;

    void Start()
    {
        HideCartelPresione();
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
    }

    public void HideCartelPresione()
    {
        if (goCartelPresione != null) goCartelPresione.SetActive(false);
    }

    public void ShowCartelPresione()
    {
        if (goCartelPresione != null) goCartelPresione.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        txtPuntaje.text = "Puntaje: " + score;
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
