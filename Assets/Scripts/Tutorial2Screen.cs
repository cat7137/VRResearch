using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2Screen : MonoBehaviour
{

    public GameObject tutorial;
    public GameObject tutorialObject;
    public Button tutorialButton1;
    public Button tutorialButton2;
    public Button backButton1;
    public Button backButton2;

    private void Awake()
    {
        tutorialButton1.onClick.AddListener(ResetObject);
        tutorialButton2.onClick.AddListener(ResetObject);
        backButton1.onClick.AddListener(ResetObject);
        backButton2.onClick.AddListener(ResetObject);
    }

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

    private void ResetObject()
    {
        tutorialObject.transform.eulerAngles = new Vector3(-90, 0, 0);
    }
}

    
