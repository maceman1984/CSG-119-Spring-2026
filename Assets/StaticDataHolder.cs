using System.Collections.Generic;
using UnityEngine;

public class StaticDataHolder : MonoBehaviour
{
    [SerializeField] public List<string> staticTopicList;


    private void Awake()
    {
        staticTopicList = new List<string>();
        DontDestroyOnLoad(this);

    }
}
