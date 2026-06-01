using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private float timer = 20f;
    private bool juegoTerminado = false;

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (!juegoTerminado)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                juegoTerminado = true;
                Time.timeScale = 0f;
            }

            uiManager.UpdateTimer(timer);
        }
    }
}