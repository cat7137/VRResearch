using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
using System.IO.Enumeration;
using Tobii.Research;
using Tobii.Research.Unity;


public class EyeDataCollection : MonoBehaviour
{
    
   
    private string filePath;
    private StreamWriter writer;
    private static List<string> eyeData;
    private EyeTrackerCollection eyeTrackers;
    


    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "EyeTrackingData.txt");
        writer = new StreamWriter(filePath);
        writer.WriteLine("LeftEyeGazePosition,RightEyeGazePosition");
        eyeData = new List<string>();
        StartCoroutine(InitializeEyeTracker());
    }

    IEnumerator InitializeEyeTracker()
    {
        

        // Retry until an eye tracker is found
        do
        {
            eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();
            
            yield return new WaitForSeconds(1f); // Wait for 1 second before retrying
        }
        while (eyeTrackers.Count == 0);

        // Assuming there's only one eye tracker, or you choose the first one
        foreach (var eyeTracker in eyeTrackers)
        {

            if (eyeTracker == null)
            {
                Debug.LogError("Failed to initialize eye tracker.");
                yield break;
            }
            else { 
            Debug.Log($"Initialized eye tracker: {eyeTracker.Address}");

                // Subscribe to gaze data received event
                if (eyeTracker != null)
                {
                    eyeTracker.HMDGazeDataReceived += EyeTracker_HMDGazeDataReceived;
                   
                    Debug.Log("Should be subscribed");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
 
    private static void EyeTracker_HMDGazeDataReceived(object sender, HMDGazeDataEventArgs e)
    {

        Debug.Log(string.Format(
            "Got HMD gaze data with {0} left eye direction described by unit vector ({1}, {2}, {3}) in the HMD coordinate system.",
            e.LeftEye.GazeDirection.Validity,
            e.LeftEye.GazeDirection.UnitVector.X,
            e.LeftEye.GazeDirection.UnitVector.Y,
            e.LeftEye.GazeDirection.UnitVector.Z));

           
            HMDEyeData leftEyeData = e.LeftEye;
            HMDEyeData rightEyeData = e.RightEye;
            HMDGazeDirection leftEyeGazeDirection = leftEyeData.GazeDirection;
            HMDGazeDirection rightEyeGazeDirection = rightEyeData.GazeDirection;
        

            string dataToWrite = $"{leftEyeGazeDirection.UnitVector},{rightEyeGazeDirection.UnitVector}";
            eyeData.Add(dataToWrite);
    }

    private void OnApplicationQuit()
    {
        foreach (var eyeTracker in eyeTrackers)
        {
           eyeTracker.HMDGazeDataReceived -= EyeTracker_HMDGazeDataReceived;
        }
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
