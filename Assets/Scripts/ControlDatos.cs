using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ControlDatos : MonoBehaviour
{
    public GameObject jugador;
    public string archivoGuardado;
    public DatosJuego datosJuego = new DatosJuego(); 
    private bool colisionado = false;
    private bool puedeGuardar = false;

    [SerializeField] private GameObject interactMark;
    [SerializeField] private TMP_Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        archivoGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void CargarDatos(){
        if(File.Exists(archivoGuardado)){
            string contenido = File.ReadAllText(archivoGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            Debug.Log("Datos cargados" + datosJuego.ToString());

            jugador.transform.position = datosJuego.posicion;
            //jugador.GetComponent<MovimientoJugador>().inventario = datosJuego.inventario;
        }else{
            Debug.Log("No se ha encontrado el archivo de guardado");
        }
    }


    public void GuardarDatos(){
        List<string> inventarioLista = new List<string>(jugador.GetComponent<MovimientoJugador>().inventario);

        dialogueText.text = "Saved.";
        DatosJuego nuevosDatos = new DatosJuego(){
            posicion = jugador.transform.position,
            inventario = inventarioLista
        };

        File.WriteAllText(archivoGuardado, JsonUtility.ToJson(nuevosDatos)); //archivo en el que guardar y datos en JSON
        Debug.Log("SAVED");


    }

    void OnTriggerStay2D(Collider2D col)
    {
        interactMark.SetActive(true);
        colisionado = true;

        // Verifica si el otro collider tiene una etiqueta específica
        if (col.gameObject.tag == "Player" && puedeGuardar)
        {
            GuardarDatos();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        colisionado = false;
        puedeGuardar = false;
        interactMark.SetActive(false);
        dialogueText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && colisionado){
            puedeGuardar = true;

        }
    }
}
