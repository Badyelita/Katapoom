using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFase : MonoBehaviour
{
    [SerializeField] GameObject HudBloques;
    [SerializeField] GameObject HudCartas;
    [SerializeField] TMP_Text text;
    [SerializeField] Button changeFaseButtonToAttack;
    [SerializeField] Button changeFaseButtonToDefense;
    [SerializeField] Button changeFaseButtonToCards;


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
        HudCartas.SetActive(false);
        
        changeFaseButtonToDefense.gameObject.SetActive(true);
        changeFaseButtonToAttack.gameObject.SetActive(false);
    }

    public void ChangeFaseCards() {
        GameManager.Instance.UpdatePlayingState(PlayingState.Cards);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        HudCartas.SetActive(true);
        HudBloques.SetActive(false);

        changeFaseButtonToAttack.gameObject.SetActive(true);
        changeFaseButtonToCards.gameObject.SetActive(false);

    }

    public void ChangeFaseDefense()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.UpdatePlayingState(PlayingState.Defense);
        text.gameObject.SetActive(true);
        HudBloques.SetActive(true);

        changeFaseButtonToCards.gameObject.SetActive(true);
        changeFaseButtonToDefense.gameObject.SetActive(false);
    }
}
