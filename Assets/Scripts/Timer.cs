using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float timeElapsed;
    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    public void TurnTimerOn()
    {
        isOn = true;
    }

    public void TurnTimerOff()
    {
        isOn = false;
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(minutes % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            timeElapsed += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
