using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool[] slots = new bool[4];

    [HideInInspector] public int currentSlotElement;

    public Transform itemPositionEmpty;

    public KeyCode Slot1Button;
    public KeyCode Slot2Button;
    public KeyCode Slot3Button;
    public KeyCode TouchMode;

    // Start is called before the first frame update
    void Start()
    {
        currentSlotElement = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TouchMode))
        {
            changeSlot(0);
        }
        else if (Input.GetKeyDown(Slot1Button))
        {
            changeSlot(1);
        }
        else if (Input.GetKeyDown(Slot2Button))
        {
            changeSlot(2);
        }
        else if (Input.GetKeyDown(Slot3Button))
        {
            changeSlot(3);
        }
        updateInventorySlots();
        updateCurrentItem();
    }

    void changeSlot(int nextSlot)
    {
        if (slots[nextSlot] == true)
        {
            currentSlotElement = nextSlot;
        }
    }
    public bool canPickUp()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == false)
            {
                return true;
            }
        }
        return false;
    }
    void updateInventorySlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(itemPositionEmpty.childCount > i)
            {
                slots[i] = true;
            }
            else
            {
                slots[i] = false;
            }
        }
    }
    void updateCurrentItem()
    {
        int i = 0;
        foreach (Transform child in itemPositionEmpty)
        {
            if (i == currentSlotElement)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
            i++;
        }
        if (slots[currentSlotElement] == false)
        {
            changeSlot(0);
        }
    }
}
