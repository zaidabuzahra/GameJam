using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DeckManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab;
    private void OnEnable()
    {
        PlayerSignals.Instance.onTurnEnter += OnPlayCardsToPlayer;
    }

    private void OnPlayCardsToPlayer(GameObject player)
    {
        StartCoroutine(TestOne(player));
    }

    IEnumerator TestOne(GameObject player)
    {
        for (int i = 0; i < 3; i++)
        {
            var card = Instantiate(cardPrefab, this.transform);
            card.transform.DOMove(player.GetComponent<PlayerController>().cardSockets[i].position, 1f);
            yield return new WaitForSeconds(1f);
        }
    }
}