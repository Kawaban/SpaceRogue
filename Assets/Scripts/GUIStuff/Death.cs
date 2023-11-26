using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private UIScriptableObject UIObject;
    void OnEnable()
    {
        int highestScore = PlayerPrefs.GetInt("highestScore");
        if (UIObject.Score > highestScore)
        {
            PlayerPrefs.SetInt("highestScore", UIObject.Score);
            highestScore=UIObject.Score;
        }
        text.text="Score: "+UIObject.Score+"\n"+"Highest Score: "+ highestScore;
    }
    public void StartGame()
    {
        AudioController.Instance.Play("ButtonClick");
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMenu()
    {
        AudioController.Instance.Play("ButtonClick");
        AudioController.Instance.Off("Theme");
        SceneManager.LoadScene("Menu");
    }

}
