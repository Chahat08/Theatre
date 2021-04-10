using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cupboard : MonoBehaviour, IInteractable
{

    public string UnlockItem;

    private GameObject inventory;

    public void Interact(DisplayImage currentDisplay)
    {
        // if the current selected slot has an item whose name is the same as UnlockItem, then
        if(inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
            Debug.Log("unlock");
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
