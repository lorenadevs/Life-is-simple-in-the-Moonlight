using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para reconocer elementos de UI (en este caso el slider)
using UnityEngine.Video;


public class comportamientoOpciones : MonoBehaviour
{
    public VideoPlayer backgroundVideo; // Referencia al componente backgroundVideo
    public Slider opacitySlider; // Referencia al slider

    public Slider volumeSlider;
    public AudioSource backgroundSound;


    private void Start(){
        // Alternativa a hacerlo con Event Trigger
        //opacitySlider.onValueChanged.AddListener(delegate { UpdateVideoOpacity(); }); // Suscribe la función de actualización al evento de cambio del deslizador
    }

    public void UpdateVideoOpacity(){
        backgroundVideo.targetCameraAlpha = opacitySlider.value;
        //Debug.Log(backgroundVideo.targetCameraAlpha);
    }

    public void UpdateVolume(){
        backgroundSound.volume = volumeSlider.value;
    }
}
