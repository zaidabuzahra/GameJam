using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Analytics;
using TMPro;
using Unity.Mathematics;
using System;

public class DeckManager : MonoBehaviour
{
    [SerializeField] 
    private FunctionLibrary soLibrary;
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private GameObject[] cards = new GameObject[3];
    [SerializeField]
    private GameObject cardText;
    public PerksLibrary[] perks = new PerksLibrary[23];

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
        StartCoroutine(ShowText(card));
        for (int i =0; i < cards.Length; i++)
        {
            if (cards[i] == card) continue;
            cards[i].SetActive(false);
        }
        //Activate Card Effect
    }

    IEnumerator ShowText(GameObject card)
    {
        Debug.Log("HUH");
        cardText.GetComponent<TextMeshPro>().text = perks[0].cardDescription;
        cardText.SetActive(true);
        yield return new WaitForSeconds(1);
        GunSignals.Instance.onGetGunClose?.Invoke();
        //PlayerSignals.Instance.onPlayerShoot = soLibrary.cardActivation;//card.GetComponent<CardController>().perk.functionNumber;
        yield return new WaitForSeconds(1);
        PlayerSignals.Instance.onPlayerCanSHoot?.Invoke();
    }
    IEnumerator TestOne(GameObject player)
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Card");
            var card = cards[i];

            var data = perks[UnityEngine.Random.Range(1,23)];
            data = perks[0];
            card.GetComponent<CardController>().perk = data;
            PlayerSignals.Instance.onPlayerShoot = soLibrary.cardActivation;
            card.SetActive(true);
            card.transform.position = transform.position;
            card.transform.DOMove(player.GetComponent<PlayerManager>().cardSockets[i].position, 1f);
            card.transform.DOScale(new Vector3(0.6039f, 0.7672f, 0.0393f), 1f);
            cards[i] = card;
            yield return new WaitForSeconds(1f);

            Debug.Log(card.transform.position);
            card.GetComponent<CardController>().Played = false;
            card.GetComponent<CardController>().SetPos(card.transform.localPosition);
        }

        PlayerSignals.Instance.onPlayerCanChoose?.Invoke();
    }
}