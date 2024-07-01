using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
using System.IO.Enumeration;
using ViveSR.anipal.Eye;
using System.Runtime.InteropServices;

public class EyeDataCollection : MonoBehaviour
{
    
   
    private string filePath;
    private StreamWriter writer;
    private static List<string> eyeDatas;
    private static  EyeData eyeData = new EyeData();
    private static bool eye_callback_registered = false;

    
    


    // Start is called before the first frame update
    void Start()
    {
        
        filePath = Path.Combine(Application.dataPath, "EyeTrackingData.txt");
        writer = new StreamWriter(filePath);
        writer.WriteLine("LeftGazeDirection,RightGazeDirection,CombinedConvergenceDistance");
        eyeDatas = new List<string>();
        
    }

 
        

 

    // Update is called once per frame
    void Update()
    {
        if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING) return;
        if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == true && eye_callback_registered == false)
        {
            SRanipal_Eye.WrapperRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye.CallbackBasic)EyeCallBack));
            eye_callback_registered = true;
        }
        else if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == false && eye_callback_registered == true)
        {
            SRanipal_Eye.WrapperUnRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye.CallbackBasic)EyeCallBack));
            eye_callback_registered = false;
        }
    }
 
   private static void Release()
    {
        if (eye_callback_registered == true)
        {
            SRanipal_Eye.WrapperUnRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye.CallbackBasic)EyeCallBack));
            eye_callback_registered = false;
        }
    }

    private void OnDisable()
    {
        Release();
    }

    void OnApplicationQuit()
    {
        Release();
        if (writer!= null)
        {
            foreach (string data in eyeDatas)
            {
                writer.WriteLine(data);
            }
            writer.Close();
        }
    }
    internal class MonoPInvokeCallbackAttribute : System.Attribute
    {
        public MonoPInvokeCallbackAttribute() { }
    }

    /// <summary>
    /// Eye tracking data callback thread
    /// Reports data at ~120hz
    /// MonoPInvokeCallback attribute required for IL2CPP scripting backend
    /// </summary>
    /// <param name="eye_data">Reference to latest eye_data</param>
    [MonoPInvokeCallback]
    private static void EyeCallBack(ref EyeData eye_data)
    {
        eyeData = eye_data;
        string dataToWrite = $"{eyeData.verbose_data.left.gaze_direction_normalized},{eyeData.verbose_data.right.gaze_direction_normalized},{eyeData.verbose_data.combined.convergence_distance_mm}";
        eyeDatas.Add(dataToWrite);

        
    }
}
