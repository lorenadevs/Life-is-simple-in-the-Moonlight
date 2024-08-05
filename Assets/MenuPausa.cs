using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players;
    public GameObject[] bsoObjects;

    void Start(){
        bsoObjects = GameObject.FindGameObjectsWithTag("Player");
        players = GameObject.FindGameObjectsWithTag("BSO"); //Para que no se acople la música
    }

    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado = false;
    public void Pausa(){
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar(){
        Debug.Log("Reanudar");
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegoPausado){
                Reanudar();
            }else{
                Pausa();
            }
        }
    }

    public void VolverMenu(){
        Time.timeScale = 1f;
        DestroyObjects(players);
        DestroyObjects(bsoObjects);
        PantallaCarga.escenaACargar = "MenuScene";
        SceneManager.LoadScene("LoadingScreen");
    }

    public void DestroyObjects(GameObject[] arr)
    {
        foreach(GameObject obj in arr){
            Destroy(obj);
        }

    }

}

