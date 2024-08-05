using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMenu : MonoBehaviour
{
    public AudioSource soundSource;

    public AudioClip soundHighLight;
    public AudioClip soundPressed;


    public void HightLightSound(){
        soundSource.clip = soundHighLight;
        soundSource.enabled = false;
        soundSource.enabled = true;
    }

    public void PressedSound(){
        soundSource.clip = soundPressed;
        soundSource.enabled = false;
        soundSource.enabled = true;
    }

}
