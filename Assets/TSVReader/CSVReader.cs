using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{

    public GameObject questionCard;
    public List<GameObject> questionList;
    StaticDataHolder sdh;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ReadCSV();
    }

    public void ReadCSV()
    {
        sdh = FindFirstObjectByType<StaticDataHolder>();
        Debug.Log("Receiving " + sdh.staticTopicList.Count + " topics to enable");

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
                    GameObject temp = Instantiate(questionCard);

                    dataBank db = temp.GetComponent<dataBank>();

                    db.topic = data_values[0];
                    db.question = data_values[1];
                    db.answerA = data_values[2];
                    db.answerB = data_values[3];
                    db.answerC = data_values[4];
                    db.answerD = data_values[5];

                    temp.gameObject.name = db.question;
                    temp.gameObject.SetActive(false);

                    questionList.Add(temp);
                }
            }
        }

        foreach(var temp in sdh.staticTopicList)
        {
            Debug.Log(temp);
        }
        foreach(GameObject obj in questionList)
        {
            if (!sdh.staticTopicList.Contains(obj.GetComponent<dataBank>().topic)) Destroy(obj);
        }
    }

    


}
