using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ComportamientoPuertaBoss : MonoBehaviour
{
    [SerializeField] private GameObject interactMark;
    public GameObject player;
    public GameObject bsoObject;

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            interactMark.SetActive(true);
            if(Input.GetKey(KeyCode.E)){
                Abrir(); 
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            interactMark.SetActive(false);
        }
    }

    public void Abrir(){
        player = GameObject.FindGameObjectWithTag("Player");
        bsoObject = GameObject.FindGameObjectWithTag("BSO"); //Para que no se acople la música
        Destroy(player);
        Destroy(bsoObject);
        if(Input.GetKey(KeyCode.E)){
            PantallaCarga.escenaACargar = "FinalBoss";
            SceneManager.LoadScene("LoadingScreen");
        }

    }

}
