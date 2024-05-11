using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Analytics;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private GameObject[] cards = new GameObject[3];
    private void OnEnable()
    {
        PlayerSignals.Instance.onTurnEnter += OnPlayCardsToPlayer;
        PlayerSignals.Instance.onPlayerChoseCard += OnPlayerChoseCard;
    }

    private void OnPlayCardsToPlayer(GameObject player)
    {
        StartCoroutine(TestOne(player));
    }

    private void OnPlayerChoseCard(GameObject card)
    {
        card.transform.DOMove(transform.position, 1f);
        card.transform.DORotate(new Vector3(90, 0,0), 1f);
        card.GetComponent<CardController>().Played = true;
        int one = 1;
        for (int i = 0; i < 3; i++)
        {
            if (cards[i] == card) continue;
            cards[i].transform.DORotate(new Vector3(0, 0, 180), 1f);
            cards[i].transform.DOMove(new Vector3(2f * one, 8f, 0), 1.5f);
            one = -2;
        }
        StartCoroutine(ResetCards(card));
    }

    IEnumerator ResetCards(GameObject card)
    {
        yield return new WaitForSeconds(1);
        for (int i =0; i < cards.Length; i++)
        {
            if (cards[i] == card) continue;
            cards[i].SetActive(false);
        }

        //Activate Card Effect

        PlayerSignals.Instance.onPlayerCanSHoot?.Invoke();
    }
    IEnumerator TestOne(GameObject player)
    {
        for (int i = 0; i < 3; i++)
        {
            var card = cards[i];
            card.SetActive(true);
            card.transform.position = transform.position;
            card.transform.DOMove(player.GetComponent<PlayerController>().cardSockets[i].position, 1f);
            cards[i] = card;
            yield return new WaitForSeconds(1f);

            Debug.Log(card.transform.position);
            card.GetComponent<CardController>().Played = false;
            card.GetComponent<CardController>().SetPos(card.transform.localPosition);
        }
    }
}