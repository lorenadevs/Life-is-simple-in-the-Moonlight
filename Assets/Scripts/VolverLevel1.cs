using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverLevel1 : MonoBehaviour
{
    [SerializeField] MovimientoJugador jugador;
    private bool colisiona = false;
    private bool puedeSalir = false;
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        colisiona = true;
        if(other.tag == "Player" && puedeSalir){
            SceneManager.LoadScene("Level1");
            posInicioLevel1.comienzaInicio = false;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        colisiona = false;
        puedeSalir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(colisiona && Input.GetKey(KeyCode.E)){
            puedeSalir = true;
        }
    }
}
