using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    private Boolean isPaused;
    [SerializeField] private GameObject pausePannel;
    void Start()
    {
        pausePannel.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused) { Pause(); }
            else { Resume(); }
        }
    }

    public void Pause()
    {
        isPaused = true;
        pausePannel.SetActive(true);
        AudioController.Instance.Play("ButtonClick");
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        AudioController.Instance.Play("ButtonClick");
        pausePannel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Menu()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        AudioController.Instance.Play("ButtonClick");
        AudioController.Instance.Off("Theme");
        SceneManager.LoadScene("Menu");
    }
}
