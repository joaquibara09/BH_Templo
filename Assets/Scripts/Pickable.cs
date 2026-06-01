using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<UIManager>().UpdateScore(
                FindObjectOfType<InteractiveArea>().AgregarPunto()
            );
            Destroy(gameObject);
        }
    }
}