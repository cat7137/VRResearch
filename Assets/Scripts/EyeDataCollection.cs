using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
using System.IO.Enumeration;
using VIVE.OpenXR.FacialTracking;
using UnityEngine.XR.OpenXR;

public class EyeDataCollection : MonoBehaviour
{
    
   
    private string filePath;
    private StreamWriter writer;
    private static List<string> eyeData;
    private Vector3 gazeDirection;
    private InputDevice eyeTrackingDevice;
    private static float[] eyeExps = new float[(int)XrEyeExpressionHTC.XR_EYE_EXPRESSION_MAX_ENUM_HTC];
    
    


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
        var feature = OpenXRSettings.Instance.GetFeature<ViveFacialTracking>();
        if (feature != null)
        {
            if (feature.GetFacialExpressions(XrFacialTrackingTypeHTC.XR_FACIAL_TRACKING_TYPE_EYE_DEFAULT_HTC, out float[] exps))
            {
                eyeExps = exps;
            }
        }
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
