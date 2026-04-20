using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("Text Separated Value Importers")]
    [Tooltip("TSV Importer for questions")]
    public CSVReader importer;
    [Tooltip("TSV Importer for exercises")]
    public ExcersiseTSV exerciseImporter; //oops typo
    // We need this imported to get the actual questions and answers

    [Space(2f)]
    [Header("Textfields")]
    [Tooltip("Question textfield")]
    public GameObject question;
    [Tooltip("Answer textfields")]
    public GameObject[] answers = new GameObject[4];
    [Tooltip("Excercise textfields")]
    public GameObject[] excercisesTF = new GameObject[4];
    // The imported text fields for displaying question and answer

    public TimerNew tn;

    private string[] dbAnswers = new string[4];
    // translation variable

    public TimerManager timer;
    public ExerciseManager em;


    void Start()
    {
        importer.ReadCSV();
        exerciseImporter.ParseExercises();
        NextQuestion(); // In place for temporary builds so that you dont have to press the next question button and see the unpolished stuff
    }

    public void NextQuestion() //Function for setting up next question + answers
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(true);
            em.exercises[i].SetActive(false);
        }
        int qID = Random.Range(1, importer.questionList.Count);
        GameObject currentQuestion = importer.questionList[qID];
        dataBank db = currentQuestion.GetComponent<dataBank>();
        dbAnswers[0] = db.answerA;
        dbAnswers[1] = db.answerB;
        dbAnswers[2] = db.answerC;
        dbAnswers[3] = db.answerD;
        // code bloat cuz of a previous mistake

        question.GetComponent<TextMeshPro>().text = db.question; // setting question text field

        int correctID = Random.Range(0, 3);


        for (int i = 0; i < answers.Length; i++)
        {
            GameObject tmp = answers[i];
            int j = Random.Range(i, answers.Length);
            answers[i] = answers[j];
            answers[j] = tmp; 
        }
        for (int i=0; i < answers.Length; i++)
        {
            answers[i].GetComponent<TextMeshPro>().text = dbAnswers[i];
        }
        em.ShuffleAndCastExercises();
        // ts blah blah garbage ngl

        timer.ResetTimer();
        timer.StartTimer();
    }

    public void CorrectAnswer()
    {
        for (int i = 1; i < answers.Length; i++)
        {
            answers[i].SetActive(false);
            //em.exercises[i].SetActive(false);
        }

        timer.StopTimer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
