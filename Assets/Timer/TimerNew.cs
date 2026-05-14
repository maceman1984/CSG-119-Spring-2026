using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerNew : MonoBehaviour
{
    public GameManager gm;
    const float queueTime = 10f;
    public GameObject button1;
    public GameObject button2;
    public GameObject timer;
    private float elapsedTime;
    private bool donski = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetString("Autoplay") == "true")
        {
            gm.NextQuestion();
            StartCoroutine(QT1());
            button1.SetActive(false);
            button2.SetActive(false);
        }
        else
        {
            timer.SetActive(false);
            gm.NextQuestion();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (donski == true) return;
        elapsedTime += Time.deltaTime;
        timer.gameObject.GetComponent<TextMeshProUGUI>().SetText(Math.Ceiling(PlayerPrefs.GetFloat("questionTime") - elapsedTime).ToString());

        if (elapsedTime > PlayerPrefs.GetFloat("questionTime"))
        {
            donski = true;
        }
    }


    IEnumerator QT1()
    {
        donski = false;
        elapsedTime = 0;
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("questionTime"));
        gm.CorrectAnswer();
        StartCoroutine(QT2());
    }

    IEnumerator QT2()
    {
        yield return new WaitForSeconds(queueTime);
        gm.NextQuestion();
        StartCoroutine(QT1());
    }

}
