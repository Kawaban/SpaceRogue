using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider shieldBar;
    [SerializeField] private GameObject shieldBarColorObj;
    [SerializeField] private GameObject healthBarColorObj;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider ReloadBar;
    [SerializeField] private GameObject backgroundReload;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private UIScriptableObject UIObject;
    [SerializeField] private Animator animatorUp;
    [SerializeField] private Animator animatorDown;

    private Color shieldColor;
    private Image shieldBarColor;
    private Color healthColor;
    private Image healthBarColor;

    void OnEnable()
    {

        shieldBarColor = shieldBarColorObj.GetComponent<Image>();
        healthBarColor = healthBarColorObj.GetComponent<Image>();

        shieldColor = shieldBarColor.color;
        healthColor = healthBarColor.color;

        UIObject.Refresh();
        UIObject.healthEventChange.AddListener(ChangeHealth);
        UIObject.shieldEventChange.AddListener(ChangeShield);
        UIObject.reloadEventChange.AddListener(ChangeReload);
        UIObject.scoreEventChange.AddListener(ChangeScore);
        UIObject.deathEvent.AddListener(EndGame);
    }

     void Start()
    {
            AudioController.Instance.Play("Theme");
    }


    public void ChangeHealth(float value)
    {
        if(value < 0.05f)
            healthBarColor.color = new Color(0f,0f,0f,0f);
        else if(healthBarColor.color != healthColor)
            healthBarColor.color = healthColor;

        healthBar.value = value;
    }
    public void ChangeShield(float value)
    {
        if (value < 0.05f)
            shieldBarColor.color = new Color(0f, 0f, 0f, 0f);
        else if (shieldBarColor.color != shieldColor)
            shieldBarColor.color = shieldColor;

        shieldBar.value = value;
    }

    public void ChangeReload(Pair<Boolean,float> value)
    {
        if (value.first)
        {
            ReloadBar.value = 1f;
            backgroundReload.GetComponent<Image>().color = Color.green;
        }
        else if (ReloadBar.value != 1f)
        {
            ReloadBar.value =value.second;
        }
        else
        {
            ReloadBar.value = 0f;
            backgroundReload.GetComponent<Image>().color = Color.red;
        }
    }

    public void ChangeScore(int value)
    {
        text.text  = "Score: " + value;
    }

    public void EndGame(int val)
    {
        StartCoroutine(SceneTransition());
    }

    private IEnumerator SceneTransition()
    {
        animatorUp.SetTrigger("TrStart");
        animatorDown.SetTrigger("TrStart");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Death");
    }

}
