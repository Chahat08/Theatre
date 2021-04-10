using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float zoomRatio = 0.5f;
    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= zoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

        gameObject.layer = 2; // layer 2 ignores raycast, so that we can't zoom in more than once at a time
        currentDisplay.CurrentState = DisplayImage.State.zoom;

        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            AudioClip clip = gameObject.GetComponent<AudioSource>().clip;
            audio.PlayOneShot(clip);
        }

        ConstraintCamera();
    }
    
    void ConstraintCamera()
    {
        // so that the camera does not zoom into the extra space outside the screen frame

        var height = Camera.main.orthographicSize; // orthographicSize = height /2 = centre to top
        var width = height * Camera.main.aspect; // since aspect=height/width (half of width = centre to side)

        var cameraBounds = GameObject.Find("cameraBounds");

        // constraint for +x (right edge)
        if(Camera.main.transform.position.x + width > cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x/2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - 
                (Camera.main.transform.position.x + width), 0, 0);
        }

        // constraint for -x (left edge)
        if (Camera.main.transform.position.x - width < cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 -
                (Camera.main.transform.position.x - width), 0, 0);
        }

        // constraint for +y (top edge)
        if (Camera.main.transform.position.y + height > cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Camera.main.transform.position += new Vector3(0, cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 -
                (Camera.main.transform.position.y + height), 0);
        }

        // constraint for -y (bottom edge)
        if (Camera.main.transform.position.y - height < cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Camera.main.transform.position += new Vector3(0, cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 -
                (Camera.main.transform.position.y - height), 0);
        }

    }
}
 