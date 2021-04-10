using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* To display and hide buttons according to the current display */

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        roomChange, returnButton
        // these are the two types of buttons there are
    }

    public ButtonId ThisButtonId;
    private DisplayImage currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    // Update is called once per frame
    void Update()
    {
        HideButtons();
        DisplayButtons();
    }


    void HideButtons()
    {
        if(currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            // this makes the button transparent since alpha channel's value is 0

            GetComponent<Button>().enabled = false;
            // and also disable the button

            this.transform.SetSiblingIndex(0);
            // all 3 btns are children of Canvas
            // the returnButton is the last, so it is highest in the heirarchy
            // if the button is placed in the same position as one of the other buttons,
            // then the other button won't be clickable because a disabled btn will on TOP of it
            // SetSiblingIndex(0) sets this disabled btn to the first index
            // so that disabling it will not create any problems even if it is in the same position as any of the other buttons.
            // THIS IS BASICALLY REDUNDANT IN OUR CASE SINCE I HAVE PUT THE BUTTON IN A NEW PLACE

        }

        if (currentDisplay.CurrentState == DisplayImage.State.zoom && ThisButtonId == ButtonId.roomChange)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            // this makes the button transparent

            GetComponent<Button>().enabled = false;
            // and also disable the button

            this.transform.SetSiblingIndex(0);
        }
    }

    void DisplayButtons()
    { 

        if (currentDisplay.CurrentState == DisplayImage.State.normal && ThisButtonId == ButtonId.roomChange)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            // alpha channel's value 1 = full opacity

            GetComponent<Button>().enabled = true;
            // button re-enabled
        }

        if (currentDisplay.CurrentState != DisplayImage.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            // alpha channel's value 1 = full opacity

            GetComponent<Button>().enabled = true;
            // button re-enabled
        }
    }
}
