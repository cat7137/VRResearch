using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{

    public GameObject tutorial;
    public GameObject tutorialObject;
    public GameObject ready;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial.activeSelf)
        {
            tutorialObject.SetActive(true);
        }

        if (ready.activeSelf)
        {
            tutorialObject.SetActive(false);
        }
       
    }
}
