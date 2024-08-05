using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posInicioLevel1 : MonoBehaviour
{
    public static bool comienzaInicio = true;
    // Start is called before the first frame update
    void Start()
    {
        if(comienzaInicio==false){
            GameObject jug = GameObject.FindGameObjectWithTag("Player");
            jug.transform.position = GameObject.FindGameObjectWithTag("spawnPoint").transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
