using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour, IInteractable
{
    public GameObject ItemPrefab;

    Transform PlayerParent;

    PlayerInventory inventoryScript;

    void Start()
    {
        PlayerParent = GameObject.FindGameObjectWithTag("ItemPosition").GetComponent<Transform>();
        inventoryScript = FindObjectOfType<PlayerInventory>();
    }
    public void Interact()
    {
        Debug.Log("Interacted");
        if (inventoryScript.canPickUp())
        {
            Instantiate(ItemPrefab, PlayerParent);
            Debug.Log("Picked Up");
            Destroy(gameObject);
        }
    }
}
