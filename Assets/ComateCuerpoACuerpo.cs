using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComateCuerpoACuerpo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe; //Para circular
    [SerializeField] private float danioGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiguienteAtaque;

    public AudioSource audioSource; //Para cambiar el temita al morir 
    public AudioClip sonidoGolpe;


    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Atacar()
    {
        animator.SetTrigger("Golpe");
        audioSource.PlayOneShot(sonidoGolpe);

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                //FinalBoss boss = colisionador.GetComponent<FinalBoss>();
                
                colisionador.transform.GetComponent<BossComportamiento>().RecibirDanio(danioGolpe);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(tiempoSiguienteAtaque > 0){
            tiempoSiguienteAtaque -= Time.deltaTime;
        }


        if(Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0){
            Atacar();
            tiempoSiguienteAtaque = tiempoEntreAtaque;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
