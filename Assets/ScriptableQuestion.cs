using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableQuestion", menuName = "Scriptable Objects/Question Card")]
public class ScriptableQuestion : ScriptableObject
{
    public string theme;

    public string qType;

    public string question;

    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
}
