using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSpiller : MonoBehaviour
{
    public GameObject oilPrefab; 

    public void SpillOil(Vector3 position)
    {
        Instantiate(oilPrefab, position, Quaternion.identity);
    }
}
