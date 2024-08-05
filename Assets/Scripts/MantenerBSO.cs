using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerBSO : MonoBehaviour
{
    // Start is called before the first frame update
    private static MantenerBSO instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
