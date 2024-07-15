using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2Screen : MonoBehaviour
{

    public GameObject tutorial;
    public GameObject tutorialObject;
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial.activeSelf)
        {
            tutorialObject.SetActive(true);
        }
    }
}
