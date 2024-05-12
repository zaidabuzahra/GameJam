using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask cardLayerMask;

    private PerksLibrary perk;
    [SerializeField]
    private Camera cam;
    private Vector3 _mousePos;
    private GameObject currentCardHover;
    private bool _canShoot, _canChoose;

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerCanSHoot += PlayerShoot;
        PlayerSignals.Instance.onPlayerCanChoose += PlayerCanChoose;
    }

    private void PlayerCanChoose()
    {
        _canChoose = true;
    }
    private void PlayerShoot()
    {
        _canShoot = true;
    }

    private void Update()
    {
        _mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(_mousePos);
        if(Physics.Raycast(ray, out RaycastHit rayHit, 999f, cardLayerMask))
        {
            if (currentCardHover != rayHit.transform.gameObject && currentCardHover != null) currentCardHover.GetComponent<CardController>().MoveBack();
            rayHit.transform.gameObject.GetComponent<CardController>().HoverCard();

            currentCardHover = rayHit.transform.gameObject;
            if (Input.GetMouseButtonDown(0) && _canChoose)
            {
                _canChoose = false;
                perk = currentCardHover.GetComponent<CardController>().perk;
                Debug.Log(perk);
                PlayerSignals.Instance.onPlayerChoseCard?.Invoke(currentCardHover);
            }
        }

        if (_canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _canShoot = false;
                Debug.LogWarning(perk.functionNumber);
                GunSignals.Instance.onPlayAnimation?.Invoke();
                PlayerSignals.Instance.onPlayerShoot?.Invoke(perk.functionNumber);

            }
        }
    }
}