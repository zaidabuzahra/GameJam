using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    public float spreadRate = 0.5f; 
    public LayerMask obstacleMask; 
    public GameObject oilSpillPrefab; 
    public GameObject firePrefab; 

    public void SpreadOil()
    {
        Instantiate(oilSpillPrefab, transform.position, Quaternion.identity);

        Vector3 spreadDirection = transform.forward; 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, spreadDirection, out hit, spreadRate, obstacleMask))
        {
            spreadDirection = Vector3.Reflect(spreadDirection, hit.normal);
        }

        transform.position += spreadDirection * spreadRate;
    }

    public void Ignite()
    {
        Instantiate(firePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            Ignite();
        }
    }
}
