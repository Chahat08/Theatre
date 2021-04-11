using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{
    public string Password;

    public GameObject OpenLockerSprite;
    public AudioSource sound;

    [HideInInspector]
    public Sprite[] numberSprites;
    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0, 0 };
    // current index is the current password

    private bool isOpen;

    private GameObject displayImage;

    // Start is called before the first frame update
    void Start()
    {
        displayImage = GameObject.Find("displayImage");

        OpenLockerSprite.SetActive(false);
        LoadAllNumberSprites();
    }

    // Update is called once per frame
    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    void LoadAllNumberSprites()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }

    bool VerifyCorrectCode()
    {
        bool correct = true;

        for(int i=0; i<5; ++i)
        {
            if (Password[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name[transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1])
            {
                //sound.Play();
                correct = false;
            }
        }

        return correct;
    }

    void OpenLocker()
    {
        if (isOpen) return;

        if (VerifyCorrectCode())
        {
            isOpen = true;
            // Debug.Log("Password correct!");
            OpenLockerSprite.SetActive(true);

            for(int i=0; i<5; ++i)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    void LayerManager()
    {
        if (isOpen) return;

        if(displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.layer = 2;
                // layer 2 is ignore raycast. so it esentially turns of the interact function of numbers in normal state
                // we only need interact in zoomed in state.
            }
        }
        else
        {
            foreach (Transform child in transform) 
            {
                child.gameObject.layer = 0;
            }
                    
        }
    }
}
