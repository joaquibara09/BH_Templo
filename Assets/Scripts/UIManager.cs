// UIManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelGameOver;
    public GameObject panelE;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtPuntaje;

    private TextMeshProUGUI txtPanelE;
    private float tiempoOcultarPanel = -1f;

    void Start()
    {
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
        panelE.SetActive(false);
        txtPanelE = panelE.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (tiempoOcultarPanel > 0)
        {
            tiempoOcultarPanel -= Time.deltaTime;
            if (tiempoOcultarPanel <= 0)
            {
                panelE.SetActive(false);
            }
        }
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
        panelGameOver.SetActive(false);
    }

    public void MostrarPantallaGameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void MostrarPanelE(string mensaje)
    {
        tiempoOcultarPanel = -1f;
        txtPanelE.text = mensaje;
        panelE.SetActive(true);
    }

    public void MostrarDestruidoPorUnSegundo()
    {
        txtPanelE.text = "Objeto destruido\n+1 punto";
        panelE.SetActive(true);
        tiempoOcultarPanel = 1f;
    }

    public void OcultarPanelE()
    {
        tiempoOcultarPanel = -1f;
        panelE.SetActive(false);
    }
}
