using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        PantallaCarga.escenaACargar = "Level1";
        SceneManager.LoadScene("LoadingScreen");    
    }

    public void QuitGame(){
        Application.Quit();
    }


}
