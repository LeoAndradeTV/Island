using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMineable : MonoBehaviour, IMineable
{
    [SerializeField] protected GameObject objectsToInstantiate;
    [SerializeField] protected int amountToInstantiate;
    [SerializeField] protected Material highlightedMaterial;
    [SerializeField] protected RectTransform progressBarRect;
    [SerializeField] protected Image progressBarBg;

    protected MeshRenderer meshRenderer;
    protected Material startingMaterial;

    protected float mineTimer;
    private float currentTimer;

    private void OnEnable()
    {
        InitializeMineable();
    }

    // Start is called before the first frame update
    void Start()
    {
        progressBarBg.gameObject.SetActive(false);
    }

    public virtual void InitializeMineable() { }

    public void Interact()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > mineTimer)
        {
            currentTimer = 0;
            Mine();
        }

        SetProgressBar();
    }

    private void SetProgressBar()
    {
        progressBarBg.gameObject.SetActive(true);
        Vector3 progressBarScale = new Vector3(currentTimer / mineTimer, progressBarRect.localScale.y, progressBarRect.localScale.z);
        progressBarRect.localScale = progressBarScale;
    }

    public void OnHoverEnter()
    {
        meshRenderer.material = highlightedMaterial;
    }

    public void OnHoverExit()
    {
        meshRenderer.material = startingMaterial;
    }

    public void Mine()
    {   
        for (int i = 0; i < amountToInstantiate; i++)
        {
            PooledObject obj = PullAndSetPooledObject();
            
            obj.GetComponent<Rigidbody>().AddForce(GetMineDirection(), ForceMode.Impulse);
        }
    }

    private PooledObject PullAndSetPooledObject()
    {
        ObjectPool pool = GetComponent<ObjectPool>();
        PooledObject obj = pool.GetPooledObject();
        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        objRb.velocity = Vector3.zero;
        objRb.transform.position = gameObject.transform.position;
        obj.gameObject.SetActive(true);
        return obj;

    }

    private Vector3 GetMineDirection()
    {
        Vector3 dir = new Vector3(Random.Range(-5f, 5f), 2f, Random.Range(-5, 5));
        return dir;
    }

    public void ShowInteractableUI()
    {
        progressBarBg.gameObject.SetActive(true);
        progressBarRect.gameObject.SetActive(true);
    }

    public void HideInteractableUI()
    {
        progressBarBg.gameObject.SetActive(false);
        progressBarRect.gameObject.SetActive(false);
    }
}
