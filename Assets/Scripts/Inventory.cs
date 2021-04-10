using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;

    void InitializeInventory()
    {
        var slots = GameObject.Find("Slots");
        foreach(Transform slot in slots.transform)
        {
            // gets the first child of the slot object
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Items/empty");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
        slots = GameObject.Find("Slots");
    }

    // Update is called once per frame
    void Update()
    {
        SelectSlot();
    }

    void SelectSlot()
    {
        foreach(Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                // if the gameobject we are iterating over is the current slot and if it's usuable then do:
                slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);

            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}
