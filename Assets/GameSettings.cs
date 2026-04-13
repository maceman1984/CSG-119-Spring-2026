using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettings : MonoBehaviour
{
    public float cardDuration;
    [SerializeField] private bool autoPlay;
    public enum QuestionTopics
    {
        ExerciseHistory,
        Fitness,
        Wisconsin,
        PopCulture,
        VideoGames
    }
    // what all needs to be included... card duration, auto play, categories, 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnumField myElement = (new EnumField("Label text", QuestionTopics.ExerciseHistory));
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateSettings()
    {
        PlayerPrefs.SetFloat("cardDuration", cardDuration);
    }


}
