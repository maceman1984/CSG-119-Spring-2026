using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timeLimit = 10f;
    float currentTime;

    public TextMeshProUGUI timerText;

    bool timerRunning = false;

    public GameManager gm;

    void Update()
    {
        if (!timerRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerRunning = false;
            TimeUp();
        }

        timerText.text = Mathf.Ceil(currentTime).ToString();
    }

    void TimeUp()
    {
        Debug.Log("Time's up!");
        // move to next question or mark wrong
        gm.CorrectAnswer();
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
        timerText.text = Mathf.Ceil(currentTime).ToString();
    }
}
