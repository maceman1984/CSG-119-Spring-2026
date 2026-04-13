using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public GameObject slider;
    public GameObject sliderText;

    public GameObject toggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("autoPlay"))
        {
            bool _temp;
            if (PlayerPrefs.GetString("autoPlay") == "true") _temp = true; else _temp = false;
            toggle.GetComponent<Toggle>().isOn = _temp;
        }
        UpdateText();
    }

    public void UpdateText()
    {
        sliderText.gameObject.GetComponent<TextMeshProUGUI>().text = Mathf.CeilToInt(slider.gameObject.GetComponent<Slider>().value).ToString();
        PlayerPrefs.SetFloat("guessTime", Mathf.CeilToInt(slider.gameObject.GetComponent<Slider>().value));
    }

    public void UpdateAutoPlay()
    {
        string temp = toggle.GetComponent<Toggle>().isOn ? "true" : "false";
        PlayerPrefs.SetString("autoPlay", temp);
    }
}
