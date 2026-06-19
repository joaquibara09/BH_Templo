// InteractiveArea.cs
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    public UIManager UIManagerScript;
    public GameManager GameManagerScript;
    private int puntajeMaximo;
    private int puntajeActual = 0;
    private Pickable pickableActual;

    void Awake()
    {
        puntajeMaximo = FindObjectsOfType<Pickable>().Length;
    }

    void Start()
    {
        UIManagerScript.UpdateScore(0, puntajeMaximo);
    }

    void Update()
    {
        if (pickableActual != null && Input.GetKeyDown(KeyCode.E))
        {
            UIManagerScript.MostrarDestruidoPorUnSegundo();
            AgregarPunto();
            pickableActual.Destruir();
            pickableActual = null;
        }
    }

    public void EntrarEnRango(Pickable p)
    {
        pickableActual = p;
        UIManagerScript.MostrarPanelD("Apreta E para destruir");
    }

    public void SalirDeRango(Pickable p)
    {
        if (pickableActual == p)
        {
            pickableActual = null;
            UIManagerScript.OcultarPanelD();
        }
    }

    public void AgregarPunto()
    {
        puntajeActual++;
        UIManagerScript.UpdateScore(puntajeActual, puntajeMaximo);
        if (puntajeActual >= puntajeMaximo)
            GameManagerScript.CondicionVictoria();
    }
}
