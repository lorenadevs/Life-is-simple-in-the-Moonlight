using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject jug = GameObject.FindGameObjectWithTag("Player");
        jug.transform.position = GameObject.FindGameObjectWithTag("spawnPoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
