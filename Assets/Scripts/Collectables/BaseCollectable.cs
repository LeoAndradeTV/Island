using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectable : MonoBehaviour, ICollectable
{

    private Transform playerTransform;
    private Rigidbody collectableRb;

    private bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        collectableRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IdleBehaviour();
        if (isCollected)
        {
            Vector3 moveDir = playerTransform.position - transform.position;
            collectableRb.AddForce(moveDir, ForceMode.Acceleration);
        }
    }
    public void Collect()
    {
        isCollected = true;
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

    public virtual void GainBenefit() { }

    public virtual void IdleBehaviour() { }

    public void SetCollectTransform(Transform collectorTransform)
    {
        playerTransform = collectorTransform;
    }


}
