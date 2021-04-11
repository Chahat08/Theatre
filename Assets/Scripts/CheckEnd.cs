using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnd : MonoBehaviour
{

    // private GameObject text;
    private GameObject check1;
    private GameObject check2;

    public float wait_time = 5f;
    public string scene = "Conclusion";

    // Start is called before the first frame update
    void Start()
    {
       // text = GameObject.Find("Text");
       // text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        check1 = GameObject.Find("check1");
        check2 = GameObject.Find("check2");

        if (check1 && check2)
        {
            // text.SetActive(true);
            // Application.Quit();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(scene);
    }
}
