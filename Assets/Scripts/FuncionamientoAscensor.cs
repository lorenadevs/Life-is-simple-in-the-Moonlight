using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionamientoAscensor : MonoBehaviour
{
    [SerializeField] Transform origen, destino;
    [SerializeField] private float velocidad = 3f;

    [SerializeField] MovimientoJugador jugador;
    public AudioSource audioSource;
    public AudioClip sonidoAscensor;

    private bool haSonado;
    
    private Vector3 moverHacia;
    void Start()
    {
        moverHacia = destino.position;
        jugador = FindObjectOfType<MovimientoJugador>();
    }

    public void ActivarAscensor()
    {
        Debug.Log("en acción");
        if(!haSonado){
            audioSource.PlayOneShot(sonidoAscensor);
            haSonado = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, moverHacia, velocidad * Time.deltaTime);

        //esto es sobre el objeto, como si creásemos un GameObject y se lo asignásemos al ascensor
        //ascensor.transform.position.......
        if(transform.position == destino.position && Input.GetKey(KeyCode.E)){ //Al llegar arriba, volver abajo
            moverHacia = origen.position;
        }

        if(transform.position == origen.position && Input.GetKey(KeyCode.E)){
            moverHacia = destino.position;
        }

    }

    void OnCollisionEnter(Collision colision)
    {
        //sonidoAscensor = Resources.Load<AudioClip>("lift");
        //jugador = FindObjectOfType<MovimientoJugador>();
        Debug.Log("col");
    }


    public IEnumerator VolverAlComienzo(){
        while(transform.position != origen.position){
            transform.position = Vector3.MoveTowards(transform.position, origen.position, velocidad * Time.deltaTime);
            Debug.Log("volviendo");
            yield return null;
        }

    }

    private void FixedUpdate(){
        
        if(jugador.colisionado){
            Debug.Log("colis");
            ActivarAscensor();

        }else{
            haSonado = false;
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
