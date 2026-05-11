using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    public GameManager gm;
    public GameObject[] exercises = new GameObject[9];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject tmp in exercises)
        {
            tmp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleAndCastExercises()
    {
        Debug.Log("Shuffle and casting");
        for (int i = 0; i < exercises.Length; i++)
        {
            GameObject tmp = exercises[i];
            int j = Random.Range(i, exercises.Length);
            exercises[i] = exercises[j];
            exercises[j] = tmp;
        }
        for (int i = 0; i < gm.excercisesTF.Length; i++)
        {
            //Debug.Log(exercises);
            exercises[i].SetActive(true);
            exercises[i].transform.position = gm.excercisesTF[i].transform.position;
            exercises[i].gameObject.transform.SetParent(gm.excercisesTF[i].gameObject.transform);
        }
    }



}
