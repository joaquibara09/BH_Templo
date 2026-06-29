// UIManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelGameOver;
    public GameObject panelE;
    public GameObject panelPuntaje;
    public TextMeshProUGUI txtTimer;
    public TextMeshProUGUI txtPuntaje;

    private TextMeshProUGUI txtPanelE;
    private float tiempoOcultarPanel = -1f;

    void Start()
    {
        if (panelWin != null) panelWin.SetActive(false);
        if (panelGameOver != null) panelGameOver.SetActive(false);
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
        txtPuntaje.text = "¡GANASTE!";
        if (panelPuntaje != null) panelPuntaje.GetComponent<Image>().color = Color.green;
    }

    public void MostrarPantallaGameOver()
    {
        txtPuntaje.text = "GAME OVER";
        if (panelPuntaje != null) panelPuntaje.GetComponent<Image>().color = Color.red;
    }

    public void MostrarPanelE(string mensaje)
    {
        tiempoOcultarPanel = -1f;
        txtPanelE.text = mensaje;
        panelE.SetActive(true);
    }

    public void MostrarColeccionadoPorUnSegundo()
    {
        txtPanelE.text = "Objeto coleccionado \n+1 punto";
        panelE.SetActive(true);
        tiempoOcultarPanel = 1f;
    }

    public void OcultarPanelE()
    {
        tiempoOcultarPanel = -1f;
        panelE.SetActive(false);
    }
}