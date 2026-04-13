using UnityEngine;


public class ExitButton : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Exit Button Pressed");
        Application.Quit();
    }

}
