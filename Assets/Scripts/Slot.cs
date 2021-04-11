using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject inventory;

    public enum property { usable, displayable, empty };
    public property ItemProperty { get; set; }

    private string displayImage;

    public AudioSource sound;

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.GetComponent<Inventory>().previousSelectedSlot = inventory.GetComponent<Inventory>().currentSelectedSlot;
        inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
        if (ItemProperty == Slot.property.displayable) DisplayItem();
    }

    /* This is the script attached to a slot object */



    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
    }

    public void DisplayItem()
    {
        inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Items/"+displayImage);
    }
}
