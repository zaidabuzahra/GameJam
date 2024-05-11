using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask cardLayerMask;
    public Transform GunSocket;
    public Transform[] cardSockets = new Transform[3];
    private Camera cam;
    private Vector3 _mousePos;
    private GameObject currentCardHover;
    public bool CanShoot, CanChoose;
    public Animator PlayerAnimator;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerShoot += OnPlayerShoot;
        GunSignals.Instance.onGetGunClose += OnGetGunClose;
    }

    private void OnGetGunClose()
    {
        Debug.Log("Works");
        //PlayerAnimator.SetTrigger("PickUp");
    }
    private void OnPlayerShoot()
    {
        //PlayerAnimator.Play(whatever);
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
            if (Input.GetMouseButtonDown(0) && CanChoose)
            {
                CanChoose = false;
                PlayerSignals.Instance.onPlayerChoseCard?.Invoke(currentCardHover);
            }
        }

        if (CanShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                CanShoot = false;
                Debug.Log("Attack");
                PlayerSignals.Instance.onPlayerShoot?.Invoke();
            }
        }
    }
}