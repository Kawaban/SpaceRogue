using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private Resolution[] resolutions;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndexs = 0;
        for(int i=0;i<resolutions.Length;i++)
        {
            options.Add(resolutions[i].width + "x" + resolutions[i].height +" "+ (int)resolutions[i].refreshRateRatio.value+"Hz");

            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
                currentResolutionIndexs = i;

    
        }
        
        
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndexs;
        resolutionDropdown.RefreshShownValue();

        float volumeValue;
        audioMixer.GetFloat("Volume", out volumeValue);
        volumeSlider.value = volumeValue;

    }

    public void GoToMenu()
    {
        AudioController.Instance.Play("ButtonClick");
        SceneManager.LoadScene("Menu");
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution= resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
