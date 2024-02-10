using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PantallaCompleta : MonoBehaviour
{
    public Toggle toggle;       //variable pantalla completa

    public TMP_Dropdown resolusionesDropdown;
    Resolution[] resoluciones;                         //array que guardara todos los tipos de resoluciones

    void Start()
    {
        if (Screen.fullScreen)                         //cuando el check este marcado, la pantalla completa esta activa     
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResolucion();
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;                  //Guarda todas las resoluciones disponibles, del ordenador que ejecuta el juego, en el array resoluciones
        resolusionesDropdown.ClearOptions();                //Borra las opciones que trae unity por defecto
        List<string> opciones = new List<string>();         //creamos una lista para nombrar el tama�o de las resoluciones que vamos a mostrar
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)       //este for es, detecta las resoluciones que tiene nuestro pc y crea el nombre de todas ellas y lo mete en la lista
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);


            //el if revisa si la opcion que hemos guardado es la que tenemos activa actualmente
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }

        resolusionesDropdown.AddOptions(opciones);           //aqui es donde agrega las opciones en la lista
        resolusionesDropdown.value = resolucionActual;       //Detecta en que resolucion estamos y que la lista este el valor correspondiente
        resolusionesDropdown.RefreshShownValue();            //actualiza la lista que tenemos guardado

        resolusionesDropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }

    public void CambiarResolucion (int indiceResolucion)     //esta funcion hace que se iguale el valor del indice de resoluciones en el editor de unity
    {
        PlayerPrefs.SetInt("numeroResolucion", resolusionesDropdown.value);
        //sabes que es ya el playerprefs macarena

        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }


    public void ActivateFullScreen(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
}
