using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioJugadorZonaDescanso : MonoBehaviour
{


    void Awake(){

    }

    void Start()
    {
        GameObject jug = GameObject.FindGameObjectWithTag("Player");
        jug.transform.position = GameObject.FindGameObjectWithTag("spawnPoint").transform.position;
        //.GetComponent<MovimientoJugador>();
        //jugador.transform.position = GameObject.FindGameObjectWithTag("spawnPoint").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
