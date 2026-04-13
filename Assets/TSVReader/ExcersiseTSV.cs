using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExcersiseTSV : MonoBehaviour
{
    public List<string> exercises = new List<string>();
    public GameManager gm;

    void Start()
    {
        //ParseExercises();
    }

    public void ParseExercises()
    {
        string filePath = Application.streamingAssetsPath + "\\Exercises";
        string[] filePaths = Directory.GetFiles(filePath, "*.tsv");

        foreach(string file in filePaths)
        {
            StreamReader strReader = new StreamReader(file);
            bool endOfFile = false;

            while (!endOfFile)
            {
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
                    exercises.Add(data_values[i]);
                }
            }
        }
    }

    public void ShuffleAndCastExercises()
    {
        for (int i = 0; i < exercises.Count; i++)
        {
            string tmp = exercises[i];
            int j = Random.Range(i, exercises.Count);
            exercises[i] = exercises[j];
            exercises[j] = tmp;
        }
        for (int i = 0; i < gm.excercisesTF.Length ; i++)
        {
            //Debug.Log(exercises);
            gm.excercisesTF[i].GetComponent<Text>().text = exercises[i];
        }
    }

}
