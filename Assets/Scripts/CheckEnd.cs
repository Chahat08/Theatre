using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnd : MonoBehaviour
{

    private GameObject text;
    private GameObject check1;
    private GameObject check2;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Text");
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        check1 = GameObject.Find("check1");
        check2 = GameObject.Find("check2");

        if (check1 && check2)
        {
            text.SetActive(true);
            Application.Quit();
        }
    }
}
