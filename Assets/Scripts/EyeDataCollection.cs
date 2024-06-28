using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
using System.IO.Enumeration;



public class EyeDataCollection : MonoBehaviour
{
    
   
    private string filePath;
    private StreamWriter writer;
    private static List<string> eyeData;
    private Vector3 gazeDirection;
    private InputDevice eyeTrackingDevice;
    
    


    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.EyeTracking, inputDevices);
        if(inputDevices.Count > 0)
        {
            
            eyeTrackingDevice = inputDevices[0];
            Debug.Log("Eye Tracker Initialized");
        }
       
        filePath = Path.Combine(Application.dataPath, "EyeTrackingData.txt");
        writer = new StreamWriter(filePath);
        writer.WriteLine("LeftEyeGazePosition,RightEyeGazePosition");
        eyeData = new List<string>();
        
    }

 
        

 

    // Update is called once per frame
    void Update()
    {
        gazeDirection = Vector3.zero;
        if (eyeTrackingDevice != null )
        {
            InputFeatureUsage<Vector3> eyeGazeDirectionUsage = new InputFeatureUsage<Vector3>("eyeGazeDirection");
            if(eyeTrackingDevice.TryGetFeatureValue(eyeGazeDirectionUsage, out Vector3 gaze))
            {
                gazeDirection = gaze;
                string dataToWrite = $"{gazeDirection}";
                eyeData.Add(dataToWrite);
            }
        }
    }
 
   

    private void OnApplicationQuit()
    {
        
        if (writer!= null)
        {
            foreach (string data in eyeData)
            {
                writer.WriteLine(data);
            }
            writer.Close();
        }
    }
}
