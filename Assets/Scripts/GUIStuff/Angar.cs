using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Angar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    public void chooseHero0()
    {
        PlayerPrefs.SetInt("heroPicker", 0);
        AudioController.Instance.Play("ButtonClick");
        text.text = "The Fighter Class has been picked";
    }

    public void chooseHero1()
    {
        PlayerPrefs.SetInt("heroPicker", 1);
        AudioController.Instance.Play("ButtonClick");
        text.text = "The Interceptor Class has been picked";
    }

    public void chooseHero2()
    {
        PlayerPrefs.SetInt("heroPicker", 2);
        AudioController.Instance.Play("ButtonClick");
        text.text = "The Sniper Class has been picked";
    }

    public void StartGame()
    {
        AudioController.Instance.Off("MenuTheme");
        AudioController.Instance.Play("ButtonClick");
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMenu()
    {
        AudioController.Instance.Play("ButtonClick");
        SceneManager.LoadScene("Menu");
    }
}
