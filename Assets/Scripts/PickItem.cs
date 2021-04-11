using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour, IInteractable
{

    public string DisplaySprite;

    private GameObject InventorySlots;

    public enum Property { usable, displayable};
    // some of the items are items that are usable: like keys
    // others are items that are displayable

    public string DisplayImage;

    public Property itemProperty;

    public void Interact(DisplayImage currentDisplay)
    {
        itemPickup();
    }

    // Start is called before the first frame update
    void Start()
    {
        // InventorySlots = GameObject.Find("Slots");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemPickup()
    {
        InventorySlots = GameObject.Find("Slots");
        foreach(Transform slot in InventorySlots.transform)
        {
            if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/"+DisplaySprite);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage);
                Destroy(gameObject);
                break;
            }
        }
    }
}
