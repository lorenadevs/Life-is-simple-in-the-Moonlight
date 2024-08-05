using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantenerJugador : MonoBehaviour
{
    // Start is called before the first frame update
    private static mantenerJugador instance;


    void Awake(){
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }

       
    }

}
