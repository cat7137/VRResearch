using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class KnowledgeDataCollection : MonoBehaviour
{

    public GameObject quiz;
    public Button one;
    public Button two;
    public Button three;
    public Button four;
    private List<string> dataCollection;
    private StreamWriter writer;
    private string filePath;

    private void Awake()
    {
        one.onClick.AddListener(ReturnOne);
        two.onClick.AddListener(ReturnTwo);
        three.onClick.AddListener(ReturnThree);
        four.onClick.AddListener(ReturnFour);
    }
    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "KnowledgeOfItemData.txt");
        writer = new StreamWriter(filePath, false);
        dataCollection = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnOne()
    {
        dataCollection.Add("1");
    }

    void ReturnTwo()
    {
        dataCollection.Add("2");
    }

    void ReturnThree()
    {
        dataCollection.Add("3");
    }

    void ReturnFour(){
        dataCollection.Add("4");
    }

    private void OnApplicationQuit()
    {
        if (writer != null)
        {
            foreach (string data in dataCollection)
            {
                writer.WriteLine(data);
            }
            writer.Close();
        }
    }
}
