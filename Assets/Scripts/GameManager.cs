// GameManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UIManagerScript;
    public float tiempoRestante;
    private bool juegoTerminado = false;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.T))
{
    UIManagerScript.MostrarPantallaWin();
}
if (Input.GetKeyDown(KeyCode.Y))
{
    UIManagerScript.MostrarPantallaGameOver();
}

    tiempoRestante -= Time.deltaTime;
    UIManagerScript.UpdateTimer(tiempoRestante);

    if (tiempoRestante <= 0)
    {
        tiempoRestante = 0;
        juegoTerminado = true;
        Time.timeScale = 0;
        UIManagerScript.MostrarPantallaGameOver();
    }
    }

    public void CondicionVictoria()
    {
        juegoTerminado = true;
        Time.timeScale = 0;
        UIManagerScript.MostrarPantallaWin();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}