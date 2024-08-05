using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossComportamiento : MonoBehaviour
{

    Collider2D esteColider;

    [SerializeField] public Transform posJugador;
    [SerializeField] private float distancia;
    public Vector3 inicio;
    private Animator animator;
    private SpriteRenderer spriteRenderer; 

    //Sistema de combate
    [SerializeField] public float vida;

    //Pelea jefe
    public Rigidbody2D rb2D;
    public bool dead = false;

    // Para saber dónde mirar

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danioAtaque;

    public AudioSource audioSource; //Para cambiar el temita al morir 
    [SerializeField]private AudioClip cancionEnding;
    private bool cancionCambiada = false;

    //Efectos ataque
    public AudioClip sonidoGolpe;
    public AudioClip sonidoMuerte;
    public AudioClip sonidoRecibirDanio;

    public void Ataque(){ //Se llama a esta función desde el evento creado en el Animator en el frame exacto en el que el jefe ataca (cuando baja el martillo)
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        audioSource.PlayOneShot(sonidoGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player")) //Si alguno de los objetos con los que colisiona es el jugador...
            {
                colisionador.transform.GetComponent<ControlVida>().TomarDanio(danioAtaque);
            }
        }
    }

    void Morir(){

        animator.SetBool("Dead", dead); //nombre del booleano del animator
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        esteColider.enabled = false;
        //audioSource.PlayOneShot(sonidoMuerte);

        if(!cancionCambiada){
            audioSource.Stop();
            cancionCambiada = true;
            audioSource.clip = cancionEnding;
            audioSource.Play();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

    void Start()
    {
        esteColider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        inicio = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        posJugador = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, posJugador.position);
        animator.SetFloat("Distancia",distancia);

        
        if(vida <= 0){
            dead = true;
            Morir();
        }

    }

    public void RecibirDanio(float dmg){
        audioSource.PlayOneShot(sonidoRecibirDanio);
        vida -= dmg;
        //animator.SetTrigger("RecibirDanio");

        if(vida <= 0){
            animator.SetTrigger("Muerte");
        }


    }

    public void MirarJugador(){
        if(transform.position.x < posJugador.position.x){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
            
        }
    
    }

    //Utilizo este
    public void Girar(Vector3 objetivo){
        if(transform.position.x < objetivo.x){
            spriteRenderer.flipX = false;
        }else{
            spriteRenderer.flipX = true;
        }
    }
}
