using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlugFixer : MonoBehaviour
{
    public string UnlockItem;

    private GameObject inventory;

    private GameObject fixedPlug;
    private GameObject check;

    public void Interact(DisplayImage currentDisplay)
    {
        // if the current selected slot has an item whose name is the same as UnlockItem, then
        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock");
            fixedPlug.SetActive(true);
            check.SetActive(true);
            inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
            inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Items/empty");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        fixedPlug = GameObject.Find("fixedPlug");
        check = GameObject.Find("check1");
        check.SetActive(false);
        fixedPlug.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
