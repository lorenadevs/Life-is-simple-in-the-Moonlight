using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadoPartida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        // Verifica si el otro collider tiene una etiqueta específica
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            // Ejecuta el código de guardado, por ejemplo, guarda el progreso del juego
            GuardarPartida();
        }
    }

    // Método para guardar el progreso del juego
    void GuardarPartida()
    {
        // Implementa aquí la lógica para guardar el progreso del juego
        Debug.Log("Partida guardada");
    }
}
