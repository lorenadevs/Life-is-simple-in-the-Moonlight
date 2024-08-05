using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantenerCam : MonoBehaviour
{
    private static mantenerCam instance;
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
