using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask cardLayerMask;
    private Camera cam;
    private Vector3 _mousePos;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        _mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(_mousePos);
        if(Physics.Raycast(ray, out RaycastHit rayHit, 999f, cardLayerMask))
        {
            rayHit.transform.gameObject.GetComponent<CardController>().HoverCard();
        }
    }
}