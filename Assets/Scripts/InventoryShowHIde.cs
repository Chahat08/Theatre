using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShowHide : MonoBehaviour
{
    public GameObject panel;
    bool state;

    void Start()
    {
        state = true;
    }

    void Update()
    {
        // SwitchShowHide();
    }

    public void SwitchShowHide()
    {
        state = !state;
        panel.gameObject.SetActive(state);
    }
}
