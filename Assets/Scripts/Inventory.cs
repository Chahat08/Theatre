using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    public GameObject itemDisplayer { get; set; }

    public AudioSource sound;

    void InitializeInventory()
    {

        slots = GameObject.Find("Slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");

        foreach(Transform slot in slots.transform)
        {
            // gets the first child of the slot object
            slot.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Items/empty");

            slot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
        }

        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;
    }


    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        SelectSlot();
        HideDisplay();
    }

    void SelectSlot()
    {
        foreach(Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                // if the gameobject we are iterating over is the current slot and if it's usuable then do:
                slot.GetComponent<Image>().color = new Color(.9f, .4f, .6f, 1);
                // sound.Play();

            }
            else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                //slot.GetComponent<Slot>().DisplayItem();
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    void HideDisplay()
    {
        if(Input.GetMouseButtonDown(0) && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            itemDisplayer.SetActive(false);
            if (currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable || currentSelectedSlot)
            {
                currentSelectedSlot = previousSelectedSlot;
                previousSelectedSlot = currentSelectedSlot;
            }
        }
    }
}
