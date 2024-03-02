using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeCard : MonoBehaviour
{
    private GameObject[] hand = new GameObject[5];
    [SerializeField] GameObject[] cards;
    [SerializeField] RectTransform parent;

    private int randomCard;

    GameObject instantiatedCard;

    Vector2 max = new (0.242f, 0.2247778f);
    Vector2 min = new (0.1822709f, 0.07314815f);
    
    private void Start()
    {
        TakeCard();
        ShowHand();
    }

    private void TakeCard()
    {
        for (int i = 0; i < hand.Length; i++) {
            randomCard = (int)Random.Range(0, 11);
            if (hand[i] == null) {
                hand.SetValue(cards[randomCard], i);
            }
        }
    }

    private void ShowHand() {
        foreach (GameObject card in hand)
        {
            instantiatedCard = Instantiate(card, parent);
            instantiatedCard.transform.localPosition = Vector3.zero;
            instantiatedCard.GetComponent<RectTransform>().anchorMax = max;
            instantiatedCard.GetComponent<RectTransform>().anchorMin = min;
            instantiatedCard.transform.localScale = new Vector3(0.75f, 0.7f, 0.75f);

            min.x = max.x;
            max.x += 0.0641f;
        }
    }
}
