using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public AudioSource sound;

    private DisplayImage currentWall;

    private float initialCameraSize;
    private Vector3 initialCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentWall = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraSize = Camera.main.orthographicSize;
        initialCameraPosition = Camera.main.transform.position;
    }

    public void OnLeftClickArrow()
    {
        sound.Play();
        currentWall.CurrentImage -= 1;
        currentWall.CurrentState = DisplayImage.State.normal;
    }
    public void OnRightClickArrow()
    {
        sound.Play();
        currentWall.CurrentImage += 1;
        currentWall.CurrentState = DisplayImage.State.normal;
    }

    public void OnClickReturn()
    {
        // we want to return from the zoomed in state (or the changed view) after clicking the buttonReturn
        sound.Play();

        if (currentWall.CurrentState == DisplayImage.State.zoom)
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
            var zoomInObjects = FindObjectsOfType<ZoomInObject>(); //each object of the zoom in type
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
                // their layer was set to 2 when we zoomed in to prevent zooming in more than once by disabling raycast
                // now we are back to the default layer, and will be able to zoom in again
            }
            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            currentWall.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.CurrentImage);
            currentWall.CurrentState = DisplayImage.State.normal;
        }
    }

}
