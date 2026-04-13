using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton1 : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("PlaySettingsScene");
    }
}
