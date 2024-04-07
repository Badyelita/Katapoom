using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
    public GameObject menuPause;
    public GameObject menuExit;
    public GameObject menuOptions;
    public GameObject dialogPanel;
    public GameObject HudJuego;
    public bool playing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }else
            {
                PauseGame();
            }
            
        }

        Debug.Log(GameManager.Instance.gameState);
        Debug.Log(GameManager.Instance.playingState);
    }


    void PauseGame()
    {
        menuPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (GameManager.Instance.gameState == GameState.Ready)
        {
            playing = false;
        }
        else
        {
            playing = true;
            HudJuego.SetActive(false);
        }
        GameManager.Instance.UpdateGameState(GameState.Paused);
        Time.timeScale=0f;
        dialogPanel.SetActive(false);
        

        isPaused =true;
    }

    public void ResumeGame()
    {
        menuPause.SetActive(false);
        menuExit.SetActive(false);
        menuOptions.SetActive(false);
        
        
        if (playing)
        {
            GameManager.Instance.UpdateGameState(GameState.Playing);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            HudJuego.SetActive(true);
        }
        else
        {
            GameManager.Instance.UpdateGameState(GameState.Ready);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            HudJuego.SetActive(false);

            Debug.Log(GameManager.Instance.gameState);
        }
        
        Time.timeScale=1.0f;
        //StartCoroutine(dialogPanel.GetComponent<DialogoScript>().coroutine);

        isPaused =false;
    }


    public void Return()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdateGameState(GameState.Ready);
        SceneManager.LoadScene("Menu de inicio");

    }
}
