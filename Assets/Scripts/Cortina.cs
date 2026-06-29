using UnityEngine;

public class Cortina : MonoBehaviour
{
    public GameObject toraLocaCerrada0;
    public GameObject toraLocaCerrada1;

    private UIManager uiManager;
    private bool playerEnRango = false;
    private bool abierta = false;

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        if (toraLocaCerrada0 != null) toraLocaCerrada0.SetActive(false);
        if (toraLocaCerrada1 != null) toraLocaCerrada1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !abierta)
        {
            playerEnRango = true;
            uiManager.MostrarPanelE("Presione E para abrir la cortina");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnRango = false;
            uiManager.OcultarPanelE();
        }
    }

    void Update()
    {
        if (playerEnRango && !abierta && Input.GetKeyDown(KeyCode.E))
        {
            abierta = true;
            playerEnRango = false;
            uiManager.OcultarPanelE();

            Vector3 escala = transform.localScale;
            escala.x = 9.12f;
            transform.localScale = escala;

            Vector3 pos = transform.position;
            pos.z = -1.031f;
            transform.position = pos;

            if (toraLocaCerrada0 != null) toraLocaCerrada0.SetActive(true);
            if (toraLocaCerrada1 != null) toraLocaCerrada1.SetActive(true);
        }
    }
}
