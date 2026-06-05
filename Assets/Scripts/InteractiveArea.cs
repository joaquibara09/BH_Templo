// InteractiveArea.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    public UIManager UIManagerScript;
    public GameManager GameManagerScript;
    public int puntajeMaximo = 3;
    private int puntajeActual = 0;

    void OnTriggerEnter(Collider other)
    {
        Pickable pickableScript = other.GetComponent<Pickable>();
        if (pickableScript != null)
        {
            UIManagerScript.ShowCartelPresione();
        }
    }

    void OnTriggerExit(Collider other)
    {
        UIManagerScript.HideCartelPresione();
    }

    public int AgregarPunto()
    {
        puntajeActual++;
        if (puntajeActual >= puntajeMaximo)
        {
            GameManagerScript.CondicionVictoria();
        }
        return puntajeActual;
    }
}