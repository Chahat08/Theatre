using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
