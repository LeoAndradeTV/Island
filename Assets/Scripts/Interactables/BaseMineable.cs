using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMineable : MonoBehaviour, IMineable
{
    [SerializeField] protected GameObject[] objectsToInstantiate;

    protected MeshRenderer meshRenderer;
    protected Material startingMaterial;
    [SerializeField]  protected Material highlightedMaterial;

    protected float mineTimer = 3f;
    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Interact()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > mineTimer)
        {
            currentTimer = 0;
            Mine();
        }
    }

    public void OnHoverEnter()
    {
        Debug.Log("Hovering");
        meshRenderer.material = highlightedMaterial;
    }

    public void OnHoverExit()
    {
        meshRenderer.material = startingMaterial;
    }

    public void Mine()
    {
        foreach (var obj in objectsToInstantiate)
        {
            GameObject inst = Instantiate(obj, transform.position, Quaternion.identity);
            inst.GetComponent<Rigidbody>().AddForce(GetMineDirection(), ForceMode.Impulse);
        }
    }

    private Vector3 GetMineDirection()
    {
        Vector3 dir = new Vector3(Random.Range(-5f, 5f), 2f, Random.Range(-5, 5));
        return dir;
    }
}
