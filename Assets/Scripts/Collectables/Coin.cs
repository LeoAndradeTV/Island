using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private float rotationSpeed = 5f;

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
        IdleBehaviour();
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
    }

    public void SetCollectTransform(Transform collectorTransform)
    {
        playerTransform = collectorTransform;
    }

    public void IdleBehaviour()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    public void DestroyCollectable()
    {
        if (gameObject.TryGetComponent(out PooledObject pooledObject))
        {
            pooledObject.DestroyPooledObject();
            return;
        }

        Destroy(gameObject);
    }
}
