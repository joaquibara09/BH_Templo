using UnityEngine;

public class Pickable : MonoBehaviour
{
    private InteractiveArea interactiveArea;

    void Awake()
    {
        interactiveArea = FindObjectOfType<InteractiveArea>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            interactiveArea.EntrarEnRango(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            interactiveArea.SalirDeRango(this);
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}