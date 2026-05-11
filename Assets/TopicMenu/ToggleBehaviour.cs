using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleBehaviour : MonoBehaviour
{
    public GameObject topicTogglePrefab;
    public List<GameObject> prefabList;
    public List<string> hashedList;
    private HashSet<string> uniqueTopics = new HashSet<string>();
    public Vector3 toggleStartPos = new Vector3(252, 188, 0);
    public GameObject canvasParent;
    public StaticDataHolder sdh;
    void Start()
    {
        ReadCSV();
    }

    // NewList<string>.Add(HashSet<string>(Data_Value[i]))


    public void ReadCSV()
    {
        //string filePath = System.IO.Path.Combine(Application.streamingAssetsPath + "\\Questions");
        string filePath = Application.streamingAssetsPath + "\\Questions";
        string[] filePaths = Directory.GetFiles(filePath, "*.tsv");
        foreach (string file in filePaths)
        {
            StreamReader strReader = new StreamReader(file);
            bool endOfFile = false;
            while (!endOfFile)
            {

                //string data_String = System.IO.File.ReadAllLines(Application.streamingAssetsPath, "_questions.tsv");
                string data_String = strReader.ReadLine();
                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }

                var data_values = data_String.Split('\t');
                for (int i = 0; i < data_values.Length; i++)
                {
                    //Debug.Log("Value: " + i.ToString() + " | " + data_values[i].ToString());
                }
                if (data_values[1] != "Question" && data_values[1] != "Needs To Complete")
                {

                    // List hello
                    // add a value
                    // value gets added and checks vs other values in list hello
                    // if its unique it returns a bool
                    // if its not then it doesnt get added and returns the opposite
                    //Debug.Log(data_values[0] + " " + uniqueTopics.Add(data_values[0]));
                    if (uniqueTopics.Add(data_values[0]) == true)
                    {
                        hashedList.Add(data_values[0]);
                    }
                }
            }
        }
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":610.306640625,"y":446.651611328125,"z":0.0},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.5,"y":1.5,"z":1.5} }
        //List<string> hashedList = new List<string>(uniqueTopics);

        //foreach(var value in uniqueTopics)
        //{

        //}
        Debug.Log(hashedList.Count + " " + uniqueTopics.Count);
        for(int i = 0; i < hashedList.Count; i++)
        {
            Debug.Log("ASDOIUJFGHVBAIDSJUVGHBSIUGVHBSERIUGH2");
            GameObject toggleTemp = Instantiate(topicTogglePrefab, canvasParent.transform);
            Vector3 pos = toggleStartPos;
            toggleTemp.transform.position = new Vector3(pos.x, pos.y - (180 * i), 0);
            toggleTemp.gameObject.name = hashedList[i];
            toggleTemp.GetComponentInChildren<TextMeshProUGUI>().text = hashedList[i];
            prefabList.Add(toggleTemp);

            

            
            foreach (string name in sdh.staticTopicList)
            {
                if (toggleTemp.gameObject.name == name)
                {
                    toggleTemp.GetComponent<Toggle>().isOn = true;
                }
            }
        }
    }

    public void ToggleSetup()
    {
        sdh.staticTopicList.Clear();

        foreach(GameObject topics in prefabList)
        {
            if (topics.gameObject.GetComponent<Toggle>().isOn)
            {
                sdh.staticTopicList.Add(topics.gameObject.name);
                Debug.Log("Added" + topics.gameObject.name + " to list");
            }
        }

        SceneManager.LoadScene("SampleScene");
        // parse the topics
        // loop instantiate them
        // add active bools to a list of strings
    }
}
