using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;    //conectar el text
    public string[] lines;                  //string con las diferentes lineas de dialogo
    public float textSpeed = 0.1f;          //velocidad de aparacion del texto
    int index;                              //indicador de por donde vamos

    void Start()
    {
        dialogueText.text = string.Empty;   //borrar texto
        StartDialogue();
    }

    private void Update()                   //aqui prepararemos el metodo para pasar de linea
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    //corrutina = es como un metodo que podemos llamar y esperar cierto tiempo en ejecutarse
    IEnumerator WriteLine()
    {
        //aqui vamos a controlar que se escriban las lineas del texto
        foreach (var letter in lines[index].ToCharArray())            //cada caracter que tengamos se va a buscar en nuestras lineas de texto
        {
            dialogueText.text += letter;                              //suma al texto cada letra
            yield return new WaitForSeconds(textSpeed);               //velocidad de texto
        }
    }

    public void NextLine()                  //metodo para cambiar de linea
    {
        if (index < lines.Length-1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine (WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
