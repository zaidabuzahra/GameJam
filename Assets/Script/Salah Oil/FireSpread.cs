using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public float spreadRate = 1.0f; 
    public float oilSpreadMultiplier = 2.0f; 
    public LayerMask obstacleMask; 
    public GameObject firePrefab; 

    public void SpreadFire(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1.0f); 
        foreach (Collider collider in colliders)
        {
            Oil oil = collider.GetComponent<Oil>();
            if (oil != null)
            {
                oil.SpreadOil(); 
                spreadRate *= oilSpreadMultiplier; 
                break; 
            }
        }

        
        RaycastHit[] hits = Physics.RaycastAll(position, Vector3.up, 1.0f);
        foreach (RaycastHit hit in hits)
        {
            Vector3 neighborPosition = hit.collider.transform.position;
            if (!Physics.Raycast(neighborPosition, Vector3.down, 1.0f, obstacleMask))
            {
                Instantiate(firePrefab, neighborPosition, Quaternion.identity);
            }
        }
    }
}
