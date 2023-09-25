using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interableLayer;
    [SerializeField] private float interactionSphereRadius;
    [SerializeField] private float interactionSphereMaxDistance;

    private IInteractable currentInteractable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(transform.position, interactionSphereRadius, transform.forward, out RaycastHit hit, interactionSphereMaxDistance, interableLayer))
        {
            currentInteractable = hit.transform.GetComponent<IInteractable>();
            if (currentInteractable != null )
            {
                currentInteractable.OnHoverEnter();
                currentInteractable.ShowInteractableUI();

                if (PlayerInput.Instance.IsInteracting)
                {
                    currentInteractable.Interact(); 
                }
            }
            
            return;

        }

        if (currentInteractable != null)
        {
            currentInteractable.OnHoverExit();
            currentInteractable.HideInteractableUI();
            currentInteractable = null;
        }

    }
}
