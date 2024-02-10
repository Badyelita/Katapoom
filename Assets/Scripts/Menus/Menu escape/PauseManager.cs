using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
    public GameObject menuPause;
    public GameObject menuExit;
    public GameObject menuOptions;
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
    }


    void PauseGame()
    {
        menuPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdateGameState(GameState.Paused);
        Time.timeScale=0f;
        isPaused=true;
        
    }

    public void ResumeGame()
    {
        menuPause.SetActive(false);
        menuExit.SetActive(false);
        menuOptions.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.Instance.UpdateGameState(GameState.Ready);
        Time.timeScale=1.0f;
        isPaused=false;
    }


    public void Return()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdateGameState(GameState.Ready);
        SceneManager.LoadScene("Menu de inicio");

    }
}
