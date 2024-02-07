using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
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
        GameManager.Instance.UpdateGameState(GameState.Paused);
        Time.timeScale=0f;
        isPaused=true;
        Debug.Log(isPaused);
    }

    void ResumeGame()
    {
        GameManager.Instance.UpdateGameState(GameState.Ready);
        Time.timeScale=1.0f;
        isPaused=false;
    }
}
