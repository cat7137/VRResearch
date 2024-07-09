using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;

public class SwitchObject : MonoBehaviour
{
    [SerializeField]
    public GameObject continueUI;
    
    [SerializeField]
    public List<GameObject> objects;
    [SerializeField]
    public Button readyBtn;
    public Button continueButton;
    public bool buttonPressed = false;
    [SerializeField]
    private int buttonIndex = -1;

    public GameObject end;
    public GameObject quiz;
    private string filePath;
    private StreamWriter writer;
    private static List<string> rotationData;

    private void Awake()
    {
        readyBtn.onClick.AddListener(ButtonPushed);
        continueButton.onClick.AddListener(ButtonPushed);
    }

   



// Start is called before the first frame update
void Start()
    {
        filePath = Path.Combine(Application.dataPath, "ObjectRotationData.txt");
        writer = new StreamWriter(filePath, false);
        rotationData = new List<string>();
        //objects = new List<GameObject>(3);
        objects[0].SetActive(false);
        objects[1].SetActive(false);
        objects[2].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonPressed)
        {
            buttonIndex++;
            buttonPressed = false;
            if (buttonIndex > objects.Count - 1)
            {
                string name = objects[buttonIndex - 1].name;
                string coords = $"{objects[buttonIndex - 1].transform.localRotation.eulerAngles}";
                rotationData.Add(name);
                rotationData.Add(coords);
                objects[buttonIndex - 1].SetActive(false);
               //IButton.SetActive(false);
                end.SetActive(true);
            }
            else if (buttonIndex == 0)
            {
                objects[buttonIndex].SetActive(true);
               //IButton.SetActive(false);
                quiz.SetActive(true);
            }
            else
            {
                objects[buttonIndex].SetActive(true);
                string name = objects[buttonIndex - 1].name;
                string coords = $"{objects[buttonIndex - 1].transform.localRotation.eulerAngles}";
                rotationData.Add(name);
                rotationData.Add(coords);
                objects[buttonIndex - 1].SetActive(false);
                continueUI.SetActive(false);
                quiz.SetActive(true);
                
               
            }
        }
    }


    private void OnApplicationQuit()
    {
        if (writer != null)
        {
            foreach (string data in rotationData)
            {
                writer.WriteLine(data);
            }
            writer.Close();
        }
    }

    private void ButtonPushed()
    {
       buttonPressed = true;
    }

    
}
