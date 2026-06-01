using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    private float tiempoTranscurrido;
    private int contador = 0;

    void Start()
    {
        tiempoTranscurrido = 0f;
        textoUI.text = "Recolectados: 0 | Tiempo: 0s";
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        textoUI.text = "Recolectados: " + contador + " | Tiempo: " + Mathf.FloorToInt(tiempoTranscurrido) + "s";
    }

    public void Recolectar()
    {
        contador++;
        Debug.Log("Recolectados: " + contador);
    }
}