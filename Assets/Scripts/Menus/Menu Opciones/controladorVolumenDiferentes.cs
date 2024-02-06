using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class controladorVolumenDiferentes : MonoBehaviour
{
    public AudioMixer myMixer;

    public Slider BGMSlider;        //BGM (Sonido de fondo) SFX (sonido de canvas)
    public Slider SFXSlider;
    public Slider MasterSlider;
    public Slider CanvasSlider;
    
    public Image imagenMute1;
    public Image imagenMute2;
    public Image imagenMute3;
    public Image imagenMute4;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGMVolume();
            SetSFXVolume();
            SetMASTERVolume();
            SetCANVASVolume();
        }        
    }
    #region ControladoresDeVolumen
    public void SetBGMVolume()      //aqui se le asigna al slider de BGM su funcion
    {
        float volumeBGM = BGMSlider.value;                         //get (obtener) set (escribir)
        myMixer.SetFloat("BGM", Mathf.Log10(volumeBGM) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volumeBGM);
        MuteBGM();
    }

    public void SetSFXVolume()      //aqui se le asigna al slider de SFX su funcion
    {
        float volumeSFX = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volumeSFX) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volumeSFX);
        MuteSFX();
    }

    public void SetMASTERVolume()      //aqui se le asigna al slider de Master su funcion
    {
        float volumeMaster = MasterSlider.value;
        myMixer.SetFloat("MASTER", Mathf.Log10(volumeMaster) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volumeMaster);
        MuteMaster();
    }

    public void SetCANVASVolume()      //aqui se le asigna al slider de Canvas su funcion
    {
        float volumeCanvas = CanvasSlider.value;
        myMixer.SetFloat("CANVAS", Mathf.Log10(volumeCanvas) * 20);
        PlayerPrefs.SetFloat("CanvasVolume", volumeCanvas);
        MuteCanvas();
    }
    #endregion

    private void LoadVolume()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetBGMVolume();
        SetSFXVolume();
        SetMASTERVolume();
        SetCANVASVolume();
    }

    #region mute
    public void MuteBGM() //el mute de BGM
    {
        if (BGMSlider.value == 0.0001f)             //el 0.0001 es debido que el valor minimo de volumen en el slider no es 0
        {                                           
            imagenMute1.enabled = true;
        }
        else
        {
            imagenMute1.enabled = false;
        }        
    }

    public void MuteSFX() //el mute de SFX
    {
        if (SFXSlider.value == 0.0001f)         
        {
            imagenMute2.enabled = true;
        }
        else
        {
            imagenMute2.enabled = false;
        }
    }

    public void MuteMaster() //el mute de Master
    {
        if (MasterSlider.value == 0.0001f)
        {
            imagenMute3.enabled = true;
        }
        else
        {
            imagenMute3.enabled = false;
        }
    }

    public void MuteCanvas() //el mute de Canvas
    {
        if (CanvasSlider.value == 0.0001f)
        {
            imagenMute4.enabled = true;
        }
        else
        {
            imagenMute4.enabled = false;
        }
    }

    #endregion
}
