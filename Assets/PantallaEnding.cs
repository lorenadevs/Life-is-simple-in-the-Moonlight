using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PantallaEnding : MonoBehaviour
{
    public GameObject endingUI; // Referencia al objeto de la pantalla de muerte en la jerarquía
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            endingUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void backToMenu(){
        Time.timeScale = 1f;
        PantallaCarga.escenaACargar = "MenuScene";
        SceneManager.LoadScene("LoadingScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
