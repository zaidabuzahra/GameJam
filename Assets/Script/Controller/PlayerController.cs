using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask cardLayerMask;
    public Transform[] cardSockets = new Transform[3];
    private Camera cam;
    private Vector3 _mousePos;
    private GameObject currentCardHover;
    public bool CanShoot;
    public Animator PlayerAnimator;
    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        PlayerSignals.Instance.onPlayerShoot += OnPlayerShoot;
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
            if (Input.GetMouseButtonDown(0))
            {
                PlayerSignals.Instance.onPlayerChoseCard?.Invoke(currentCardHover);
            }
        }

        if (CanShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerSignals.Instance.onPlayerShoot?.Invoke();
            }
        }
    }
}