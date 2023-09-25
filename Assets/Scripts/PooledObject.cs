using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool myPool;

    private float timer;
    private float maxTimer;
    private bool shouldDestroy;

    // Update is called once per frame
    void Update()
    {
        if (shouldDestroy)
        {
            timer += Time.deltaTime;

            if (timer > maxTimer)
            {
                timer = 0;
                shouldDestroy = false;
                myPool.RestoreObject(this);
            }
        }
    }

    public void DestroyPooledObject()
    {
        gameObject.SetActive(false);
        myPool.RestoreObject(this);

    }

    public void DestroyPooledObjectWithTime(float time)
    {
        maxTimer = time;
        shouldDestroy = true;
    }

    public void SetObjectPool(ObjectPool pool)
    {
        myPool = pool;
    }
}
