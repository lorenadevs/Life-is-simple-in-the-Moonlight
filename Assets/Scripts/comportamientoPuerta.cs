using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class comportamientoPuerta : MonoBehaviour
{

    [SerializeField] private GameObject interactMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] MovimientoJugador jugador;

    void IntentarAbrirPuerta(){//TODO AÑADIR
        if((jugador.inventario[0]=="llave" && Input.GetKey(KeyCode.E))){
            Debug.Log("tiene llave");

            SceneManager.LoadScene("RestZone");


        }else if(Input.GetKey(KeyCode.E)){
            dialoguePanel.SetActive(true);
            dialogueText.text = "It's locked.";
            Debug.Log("no tiene llave");
        }
    }

    void OnCollisionStay2D(Collision2D col){//Con el Stay nos olvidamos de corutinas
        if(col.gameObject.tag == "Player"){
            interactMark.SetActive(true);
            IntentarAbrirPuerta(); 
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            interactMark.SetActive(false);
            dialogueText.text = string.Empty;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
