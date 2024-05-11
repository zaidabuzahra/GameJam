using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera mainCamera; 
    public OilSpiller oilSpiller;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                oilSpiller.SpillOil(hit.point);
            }
        }
    }
}
