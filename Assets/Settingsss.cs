using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settingsss : MonoBehaviour
{
    public GameObject slider;
    public GameObject sliderValue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.gameObject.GetComponent<Slider>().value = (PlayerPrefs.HasKey("questionTime") ? PlayerPrefs.GetFloat("questionTime") : 15);
        PlayerPrefs.SetFloat("questionTime", slider.gameObject.GetComponent<Slider>().value);
        sliderValue.gameObject.GetComponent<TextMeshProUGUI>().text = "Question Time: " + slider.gameObject.GetComponent<Slider>().value;
        
        
        if (PlayerPrefs.HasKey("Autoplay"))
        {
            this.gameObject.GetComponent<Toggle>().isOn = PlayerPrefs.GetString("Autoplay") == "true" ? true : false;
        }
        else
        {
            this.gameObject.GetComponent<Toggle>().isOn = false;
            PlayerPrefs.SetString("Autoplay", "false");
        }
        
       // PlayerPrefs.SetString("Autoplay", this.gameObject.GetComponent<Toggle>().isOn.ToString());
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
        sliderValue.gameObject.GetComponent<TextMeshProUGUI>().text = "Question Time: " + slider.gameObject.GetComponent<Slider>().value;
    }
}
