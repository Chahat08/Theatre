using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerNumber : MonoBehaviour, IInteractable
{
    public void Interact(DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]++;
        // index of sibling 1 = 0, last = 4
        // so we are increasing the number by one on each click

        if (transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] > 9)
            transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<NumberLock>().numberSprites[transform.parent.GetComponent<NumberLock>().currentIndividualIndex[transform.GetSiblingIndex()]];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
