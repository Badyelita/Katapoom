using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoVolumen : MonoBehaviour
{
    public Slider slider;
    public float CampiarVolumen;
    public Image imagenMute;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);  //con esto se guardara para siempre las preferencias que pongamos
        AudioListener.volume = slider.value;                        //sacamos el volumen del juego
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        slider.value = valor;
        PlayerPrefs.SetFloat("volumenAudio", CampiarVolumen);         //le colocamos un valor con el set, con el get solo invocamos
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()                                //revisar si el volumen es 0 para activar un icono
    {
        if (CampiarVolumen == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }

}
