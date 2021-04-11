using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickAfterZoom : MonoBehaviour
{
    private GameObject displayImage;

    // Start is called before the first frame update
    void Start()
    {
        displayImage = GameObject.Find("displayImage");   
    }

    // Update is called once per frame
    void Update()
    {
        LayerManager();
    }

    void LayerManager()
    {
        if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            gameObject.layer = 2;
        }
        else gameObject.layer = 0;
    }
}
