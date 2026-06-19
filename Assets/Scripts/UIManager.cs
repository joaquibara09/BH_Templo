// UIManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelGameOver;
    public GameObject panelD;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtPuntaje;

    private TextMeshProUGUI txtPanelD;
    private float tiempoOcultarPanel = -1f;

    void Start()
    {
        panelWin.SetActive(false);
        panelGameOver.SetActive(false);
        panelD.SetActive(false);
        txtPanelD = panelD.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (tiempoOcultarPanel > 0)
        {
            tiempoOcultarPanel -= Time.deltaTime;
            if (tiempoOcultarPanel <= 0)
            {
                panelD.SetActive(false);
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

    public void MostrarPanelD(string mensaje)
    {
        tiempoOcultarPanel = -1f;
        txtPanelD.text = mensaje;
        panelD.SetActive(true);
    }

    public void MostrarDestruidoPorUnSegundo()
    {
        txtPanelD.text = "Objeto destruido\n+1 punto";
        panelD.SetActive(true);
        tiempoOcultarPanel = 1f;
    }

    public void OcultarPanelD()
    {
        tiempoOcultarPanel = -1f;
        panelD.SetActive(false);
    }
}
