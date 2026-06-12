// InteractiveArea.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    public UIManager UIManagerScript;
    public GameManager GameManagerScript;
    private int puntajeMaximo;
    private int puntajeActual = 0;

    void Awake()
    {
        puntajeMaximo = FindObjectsOfType<Pickable>().Length;
    }

    void Start()
    {
        UIManagerScript.UpdateScore(0, puntajeMaximo);
    }

    public void AgregarPunto()
    {
        puntajeActual++;
        UIManagerScript.UpdateScore(puntajeActual, puntajeMaximo);
        if (puntajeActual >= puntajeMaximo)
        {
            GameManagerScript.CondicionVictoria();
        }
    }
}