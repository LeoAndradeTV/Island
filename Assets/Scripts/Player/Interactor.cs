using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interableLayer;

    private IInteractable currentMineable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, 2f, transform.forward, out RaycastHit hit, 2f, interableLayer))
        {
            Debug.Log("Colliding");
            currentMineable = hit.transform.GetComponent<IInteractable>();
            if (currentMineable != null )
            {
                currentMineable.OnHoverEnter();

                if (PlayerInput.Instance.IsInteracting)
                {
                    currentMineable.Interact();
                }
            }
            
            return;

        }

        if (currentMineable != null)
        {
            currentMineable.OnHoverExit();
            currentMineable = null;
        }

    }
}
