using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
         AudioController.Instance.Play("MenuTheme");
    }
    public void StartGame()
    {
        AudioController.Instance.Play("ButtonClick");
        AudioController.Instance.Off("MenuTheme");
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToAngar()
    {
        AudioController.Instance.Play("ButtonClick");
        SceneManager.LoadScene("Angar");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
