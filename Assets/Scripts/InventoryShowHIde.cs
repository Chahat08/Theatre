using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShowHide : MonoBehaviour
{
    public GameObject panel;
    bool state;
    public AudioSource sound;

    void Start()
    {
        // state = true;
    }

    void Update()
    {
        // SwitchShowHide();
    }

    public void SwitchShowHide()
    {
        /*state = !state;
        panel.gameObject.SetActive(state);*/
        sound.Play();
        Animator animator = panel.GetComponent<Animator>();
        if(animator!=null)
        {
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);
        }
    }
}
