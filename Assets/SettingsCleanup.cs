using UnityEngine;

public class SettingsCleanup : MonoBehaviour
{
    // oopsie guess who forgor DontDestroyOnLoad objects just dont destroy unless you tell them too tee hee -Ethan
    void Start()
    {
        Destroy(FindFirstObjectByType(typeof(StaticDataHolder)));
    }
}
