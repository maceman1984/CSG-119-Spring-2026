using UnityEngine;
using UnityEngine.SceneManagement;

public class Okbutton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
   
}
