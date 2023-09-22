using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ICollectable collectable))
        {
            collectable.SetCollectTransform(transform);
            collectable.Collect();    
        }
    }
}
