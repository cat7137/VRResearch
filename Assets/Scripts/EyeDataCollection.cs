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
    
    


    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "EyeTrackingData.txt");
        writer = new StreamWriter(filePath);
        writer.WriteLine("LeftEyeGazePosition,RightEyeGazePosition");
        eyeData = new List<string>();
        
    }

 
        

 

    // Update is called once per frame
    void Update()
    {
       
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
