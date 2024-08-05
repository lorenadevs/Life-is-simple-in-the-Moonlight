using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PantallaMuerte : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] bsoObject;
    public GameObject deathScreenUI; // Referencia al objeto de la pantalla de muerte en la jerarquía
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        bsoObject = GameObject.FindGameObjectsWithTag("BSO"); //Para que no se acople la música
    }


   public void DestroyObjects(GameObject[] arr)
    {
        foreach(GameObject obj in arr){
            Destroy(obj);
        }

    }

    public void Reintentar(){
        PantallaCarga.escenaACargar = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LoadingScreen");
        Time.timeScale = 1f;

    }

    public void VolverMenu(){
        PantallaCarga.escenaACargar = "MenuScene";
        SceneManager.LoadScene("LoadingScreen");


        Time.timeScale = 1f;
        DestroyObjects(player);
        DestroyObjects(bsoObject);
    }

    //Como corutina para esperar a que se muestre la animación de muerte
    public IEnumerator MostrarPantallaMuerte()
    {
        yield return new WaitForSeconds(1f);

        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
