using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVida : MonoBehaviour
{

    [SerializeField] private Image barraVida;

    public float vidaActual;
    private float vidaMax;
    public PantallaMuerte pantallaMuerte;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        vidaMax = 100;
        vidaActual = vidaMax;
        animator = GetComponent<Animator>();
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.tag == "spawnPoint")
    //     {
    //         vidaMax = 100;
    //         vidaActual = vidaMax;
    //         barraVida = GameObject.Find("HUD").GetComponentInChildren<Image>();
    //         animator = GetComponent<Animator>();
    //     }
    // }

    public void TomarDanio(float danio)
    {
        vidaActual -= danio;
        barraVida.fillAmount = vidaActual;
        if(vidaActual <= 0)
        {
            vidaActual = 0;
            animator.SetTrigger("Muerto");
            StartCoroutine(pantallaMuerte.MostrarPantallaMuerte());

        }
    }

    // Update is called once per frame
    void Update()
    {

        barraVida.fillAmount = vidaActual / vidaMax;

    }
}
