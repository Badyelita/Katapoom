using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFase : MonoBehaviour
{
    [SerializeField] Button block;
    [SerializeField] TMP_Text text;
    [SerializeField] Button changeFaseButtonToAttack;
    [SerializeField] Button changeFaseButtonToDefense;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFaseAttack()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdatePlayingState(PlayingState.Attack);
        text.gameObject.SetActive(false);
        block.gameObject.SetActive(false);
        changeFaseButtonToDefense.gameObject.SetActive(true);
        changeFaseButtonToAttack.gameObject.SetActive(false);
    }

    public void ChangeFaseDefense()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdatePlayingState(PlayingState.Defense);
        text.gameObject.SetActive(true);
        block.gameObject.SetActive(true);
        changeFaseButtonToAttack.gameObject.SetActive(true);
        changeFaseButtonToDefense.gameObject.SetActive(false);
    }
}
