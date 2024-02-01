using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{
    public Slider volumeSlider;
    public Image imagenMute;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))         //Este if es para que si no hay diccionario de "musicVolume" se cree
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();            
        }        
    }

    public void ChangeVolume() {                    //Esta funcion se repite todo el rato
        AudioListener.volume = volumeSlider.value;  //en el audioListener está el volumen dentro de unity, el volumen del juego es igual al slider
        Save();
        Mute();
    }

    private void Load()
    {
        //el "get" recupera un valor, el "set" asigna un valor una variable
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", volumeSlider.value);
    }

    private void Save()
    {
        //PlayerPrefs es una clase que almacena las preferencias de los jugadores entre sesiones de juego.
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);  //se guarda en el guardado musicVolume el valor del slider
    }

    public void Mute()
    {
        if (volumeSlider.value == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
