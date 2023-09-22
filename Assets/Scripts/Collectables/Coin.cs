using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    private Transform playerTransform;

    private Rigidbody coinRb;

    private bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
        {
            Vector3 moveDir = playerTransform.position - transform.position;
            coinRb.AddForce(moveDir, ForceMode.Acceleration);
        }
    }

    public void Collect()
    {
        isCollected = true;
    }

    public void GainBenefit()
    {
        Debug.Log($"Gained 1 coin");
        Destroy(gameObject);
    }

    public void SetCollectTransform(Transform collectorTransform)
    {
        playerTransform = collectorTransform;
    }
}
