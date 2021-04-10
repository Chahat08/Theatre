using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageObjects : MonoBehaviour
{

    private DisplayImage currentDisplay;

    public GameObject[] objectsToManage;

    public GameObject[] UIRenderObjects;


    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();
    }
    
    // Update is called once per frame
    void Update()
    {
        ManageTheObjects();
    }



    void ManageTheObjects()
    {
        // to activate all objects in the current wall. (current display)
        for(int i =0; i<objectsToManage.Length; ++i)
        {
            if (objectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                objectsToManage[i].SetActive(true);
            }
            else objectsToManage[i].SetActive(false);
        }
    }

    void RenderUI()
    {
        for(int i=0; i<UIRenderObjects.Length; ++i)
        {
            UIRenderObjects[i].SetActive(false);
        }
    }
}
