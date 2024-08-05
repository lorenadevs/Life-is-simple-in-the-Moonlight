using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add the missing using statement for UnityEngine.UI namespace

public class MovimientoJugador : MonoBehaviour
{

    public PantallaMuerte pantallaMuerte; //Para mostrar al morir en pinchos

    private Rigidbody2D rb2D;

    private float movHorizontal = 0f;
    [SerializeField] private float velocidadMovimiento; //Serializable o ponerla pública
    [Range(0, 0.3f)][SerializeField] private float suavizadoMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [SerializeField] FuncionamientoAscensor ascensor;
    [SerializeField] comportamientoPuerta puerta;
    public bool colisionado = false;

    public string[] inventario = new string[10];

    public int vida;

    

[Header("Salto")]

    [SerializeField] private float fuerzaSalto;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private LayerMask queEsSuelo; //capa en la que todos los objetos que estén aquí se detectarán como colisión en FixedUpdate()
    [SerializeField] private Vector3 dimensiones;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    //public Vector3 posicionSalida;

    // Start is called before the first frame update
    void Start()
    {
        ascensor = FindObjectOfType<FuncionamientoAscensor>();
        puerta = FindObjectOfType<comportamientoPuerta>();
        rb2D = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spawnPoint")
        {
            Debug.Log("spawn");
            ascensor = FindObjectOfType<FuncionamientoAscensor>();
            puerta = FindObjectOfType<comportamientoPuerta>();
            rb2D = GetComponent<Rigidbody2D>();   
            animator = GetComponent<Animator>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        movHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movHorizontal)); //Con valor absoluto siempre será positivo y controlamos mejor la animación

        if(Input.GetButtonDown("Jump")){
            salto = true;
            Debug.Log("Salto");
        }
    }

    [Header("Animación")]
    private Animator animator;

    private void FixedUpdate(){
        //Suelo mientras que la caja que añadimos al personaje colisione con algo
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensiones, 0f, queEsSuelo); //Comprueba si el personaje está en el suelo
        //0f se alinea con Z

        animator.SetBool("enSuelo", enSuelo); //el nombre del booleano creado por interfaz, y la variable que le da valor

        MoverPersonaje(movHorizontal * Time.fixedDeltaTime, salto); //Lo multiplicamos por deltatime para que el movimiento sea el mismo en cualquier PC, ya que el fixedDeltaTime es el tiempo que tarda en ejecutarse un frame

        salto = false;
    }

    private void MoverPersonaje(float mover, bool saltar){
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);

        //Pasar con animación suave del punto origen al destino
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento); //Suave movimiento del personaje al moverse de izquierda a derecha, teniendo en cuenta la velocidad y el punto al que estemos yendo
    
        if(mover > 0 && !mirandoDerecha){
            Girar();
        }else if(mover < 0 && mirandoDerecha){
            Girar();
        }

        if((enSuelo || colisionado)&& saltar){
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto)); //Fuerza para saltar hacia arriba. El 0f es para que no se mueva en el eje x
        }
    }


    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensiones);
    }


    void OnCollisionEnter2D(Collision2D colision)
    {
        if(colision.gameObject.tag == "ascensor"){ //Crear esta etiqueta en Unity y añadírsela al objeto
            Debug.Log("col");
            //transform.parent = colision.transform; //El jugador se convierte en hijo del ascensor para que vayan a la misma velocidad
            colisionado = true;

        }else if(colision.gameObject.tag == "llave"){
            inventario[0] = "llave";
            Destroy(colision.gameObject);
        }else if(colision.gameObject.tag == "pinchos"){
            vida = 0;

            StartCoroutine(pantallaMuerte.MostrarPantallaMuerte());
        }
    }



    void OnCollisionExit2D(Collision2D colision) 
    {
        if(colision.gameObject.tag == "ascensor"){
            //transform.parent = null; //El jugador deja de ser hijo del ascensor
            colisionado = false;
            StartCoroutine(ascensor.VolverAlComienzo());

        }
    }
}
