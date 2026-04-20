using UnityEngine;
using UnityEngine.UI;

public class Settingsss : MonoBehaviour
{
    public GameObject slider;
    public GameObject sliderValue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.gameObject.GetComponent<Slider>().value = (PlayerPrefs.HasKey("questionTime") ? PlayerPrefs.GetFloat("questionTime") : 15);
        sliderValue.gameObject.GetComponent<Text>().text = "Question Time: " + slider.gameObject.GetComponent<Slider>().value;
        this.gameObject.GetComponent<Toggle>().isOn = PlayerPrefs.GetString("Autoplay") == "true" ? true : false;
    }

    public void AutoPlay()
    {
        if (PlayerPrefs.GetString("Autoplay") == "false")
        {
            PlayerPrefs.SetString("Autoplay", "true");
            
        }
        else
        {
            PlayerPrefs.SetString("Autoplay", "false");
        }
        Debug.Log(this.gameObject.GetComponent<Toggle>().isOn);
    }

    public void QTime()
    {
        Debug.Log("Value Change!");
        PlayerPrefs.SetFloat("questionTime", slider.gameObject.GetComponent<Slider>().value);
        sliderValue.gameObject.GetComponent<Text>().text = "Question Time: " + slider.gameObject.GetComponent<Slider>().value;
    }
}
