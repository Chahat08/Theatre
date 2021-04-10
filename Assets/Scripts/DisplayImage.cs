using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    private int currentImage;
    private int prevImage;

    // enum defining state for interactable objects
    public enum State
    {
        normal, zoom, changedView
    };

    public State CurrentState { get; set; }

    public int CurrentImage
    {
        get
        {
            return currentImage;
        }
        set
        {
            if (value > 4) currentImage = 1;
            else if (value < 1) currentImage = 4;
            else currentImage = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentImage = 1;
        prevImage = 0;
        // camPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (prevImage != currentImage)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentImage);
            }
            prevImage = currentImage;
        
    }
}
