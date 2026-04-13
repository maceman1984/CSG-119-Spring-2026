using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    [Space(2f)]
    [Header("Debug Stuffs")]
    [Tooltip("Timer Manager script for referencing")]
    public TimerManager timer;
    [Tooltip("Setting for game pacing")]
    public bool autoPlay;
    [Tooltip("Setting for game pacing")]
    public float guessDuration;
    [Tooltip("Setting for game pacing")]
    public float defaultAnswerDuration = 15f;


    private string[] dbAnswers = new string[4];
    // translation variable



    void Start()
    {
        autoPlay = autoPlayParse();
        importer.ReadCSV();
        exerciseImporter.ParseExercises();
        NextQuestion(); // In place for temporary builds so that you dont have to press the next question button and see the unpolished stuff

    }
    bool autoPlayParse()
    {
        string temp = PlayerPrefs.GetString("autoPlay");
        if (temp == "true") return true;
        else return false;
    }
    public void NextQuestion() //Function for setting up next question + answers
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(true);
        }
        int qID = Random.Range(1, importer.questionList.Count);
        GameObject currentQuestion = importer.questionList[qID];
        dataBank db = currentQuestion.GetComponent<dataBank>();
        dbAnswers[0] = db.answerA;
        dbAnswers[1] = db.answerB;
        dbAnswers[2] = db.answerC;
        dbAnswers[3] = db.answerD;
        // code bloat cuz of a previous mistake

        question.GetComponent<Text>().text = db.question; // setting question text field

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
            answers[i].GetComponent<Text>().text = dbAnswers[i];
        }
        exerciseImporter.ShuffleAndCastExercises();
        // ts blah blah garbage ngl
        timer.ResetTimer();
        if (!autoPlay) return;
        timer.StartTimer();
    }

    public void CorrectAnswer()
    {
        for (int i = 1; i < answers.Length; i++)
        {
            answers[i].SetActive(false);
        }

        timer.StopTimer();
        if (autoPlay) StartCoroutine(CorrectAnswerTimer()); // auto progress to next question if autoPlay is true
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void GameFlow() // this is a fake function for deciding the game flow with comments.
    {
        // Ready set go
        // Display stuffs
        // Start timer
        // Play music
        // Timer ends ->
        // Display correct answer
        // Custom wait time for going next page
        // NextQuestion()
    }

    IEnumerator CorrectAnswerTimer()
    {
        yield return new WaitForSeconds(catPrompt());
        NextQuestion();
    }
    private float catPrompt()
    {
        if (PlayerPrefs.HasKey("answerTime"))
        {
            return PlayerPrefs.GetFloat("answerTime");
        }
        else
        {
            return defaultAnswerDuration;
        }
    }
}
