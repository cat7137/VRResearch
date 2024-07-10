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
    public GameObject cameraObject;
    public GameObject end;
    public GameObject quiz;
    private string filePath;
    private StreamWriter writer;
    private static List<string> rotationData;

    /// <summary>
    /// Calls the ButtonPushed method when the ready or 
    /// continue buttons are pushed 
    /// </summary>
    private void Awake()
    {
        readyBtn.onClick.AddListener(ButtonPushed);
        continueButton.onClick.AddListener(ButtonPushed);
    }

   



// Start is called before the first frame update
/// <summary>
/// In start, the filePath is created to write the objectRotation
/// data to, and everything else is initialized 
/// all objects are set to inactive
/// </summary>
void Start()
    {
        filePath = Path.Combine(Application.dataPath, "ObjectRotationData.txt");
        writer = new StreamWriter(filePath, false);
        rotationData = new List<string>();
        objects[0].SetActive(false);
        objects[1].SetActive(false);
        objects[2].SetActive(false);
        
    }

    // Update is called once per frame
    /// <summary>
    /// In update, if the UI button is recognized as pushed,
    /// the buttonIndex will increase, reset the buttonPressed bool
    /// and check for three things:
    /// 1. If the buttonIndex is greater than the num of objects
    /// then the last object's name and rotation coordinates will be 
    /// recorded and added to the data list as well as the camera position
    /// and rotation coordinates, the last object 
    /// will be set to inactive, and the end screen will appear
    /// 2. If the buttonIndex is Zero, the starting object will be set to active
    /// and the quiz screen will appear 
    /// 3. Otherwise, the current object will be deactivated, its name and last 
    /// rotation coordinates will be recorded and added to the data list as well as the camera 
    /// position/rotation coordinates, and the next 
    /// object will be activated along with the Quiz screen again
    /// </summary>
    void Update()
    {

        if (buttonPressed)
        {
            buttonIndex++;
            buttonPressed = false;
            if (buttonIndex > objects.Count - 1)
            {
                string cameraName = cameraObject.name;
                string cameraPosition = $"Camera Position: {cameraObject.transform.localPosition}";
                string cameraRotation = $"Camera Rotation: {cameraObject.transform.localRotation.eulerAngles}";
                string name = objects[buttonIndex - 1].name;
                string coords = $"{objects[buttonIndex - 1].transform.localRotation.eulerAngles}";
                rotationData.Add(cameraName);
                rotationData.Add(cameraPosition);
                rotationData.Add(cameraRotation);
                rotationData.Add(name);
                rotationData.Add(coords);
                objects[buttonIndex - 1].SetActive(false);
                end.SetActive(true);
            }
            else if (buttonIndex == 0)
            {
                objects[buttonIndex].SetActive(true);
                quiz.SetActive(true);
            }
            else
            {
                objects[buttonIndex].SetActive(true);
                string cameraName = cameraObject.name;
                string cameraPosition = $"Camera Position: {cameraObject.transform.localPosition}";
                string cameraRotation = $"Camera Rotation: {cameraObject.transform.localRotation.eulerAngles}";
                string name = objects[buttonIndex - 1].name;
                string coords = $"{objects[buttonIndex - 1].transform.localRotation.eulerAngles}";
                rotationData.Add(cameraName);
                rotationData.Add(cameraPosition);
                rotationData.Add(cameraRotation);
                rotationData.Add(name);
                rotationData.Add(coords);
                objects[buttonIndex - 1].SetActive(false);
                continueUI.SetActive(false);
                quiz.SetActive(true);
                
               
            }
        }
    }

    /// <summary>
    /// When the application quits:
    /// Each line of data in the list of data is written
    /// to the file and the writer is closed 
    /// </summary>
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

    /// <summary>
    /// Turns the buttonPressed variable to true
    /// if the button is pressed
    /// </summary>
    private void ButtonPushed()
    {
       buttonPressed = true;
    }

    
}
