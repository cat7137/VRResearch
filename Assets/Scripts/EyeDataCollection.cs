using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
using System.IO.Enumeration;

public class EyeDataCollection : MonoBehaviour
{
    private Transform leftEyeTransform;
    private Transform rightEyeTransform;
    private Transform fixationPointTransform;
    private Vector3 leftEyePosition;
    private Vector3 rightEyePosition;
    private Vector3 fixationPoint;
    private Eyes eyes;
    private string filePath;
    private StreamWriter writer;
    
    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "EyeTrackingData.txt");
        writer = new StreamWriter(filePath, true);
        writer.WriteLine("LeftEyePosition,RightEyePosition,FixationPoint");
        Debug.Log("DataWriter initialized. File Path:" + filePath);
    }

    // Update is called once per frame
    void Update()
    {
        if(eyes.TryGetLeftEyePosition(out leftEyePosition))
        {
            leftEyeTransform.localPosition = leftEyePosition;
        }
        if(eyes.TryGetRightEyePosition(out rightEyePosition))
        {
            rightEyeTransform.localPosition = rightEyePosition;
        }
        if(eyes.TryGetFixationPoint(out fixationPoint))
        {
            fixationPointTransform.localPosition = fixationPoint;
        }
        string dataToWrite = $"{leftEyeTransform},{rightEyeTransform},{fixationPointTransform}";
        writer.WriteLine(dataToWrite);
    }

    private void OnDestroy()
    {
        if (writer!= null)
        {
            writer.Close();
        }
    }
}
