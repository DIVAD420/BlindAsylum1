using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class InteractionScript : MonoBehaviour
{
    public float interactionRange;
    public KeyCode interactButton;

    public LayerMask interactLayerMask;

    public GameObject InteractText;

    bool canPlayerInteract;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canPlayerInteract = Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, interactLayerMask);

        if (canPlayerInteract)
        {
            //Looking at, code
            InteractText.SetActive(true);

            //interact code
            if (Input.GetKeyDown(interactButton))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
        else
        {
            InteractText.SetActive(false);
        }
    }
}
