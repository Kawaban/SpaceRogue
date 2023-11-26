using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField] private Build heroBuildSniper;
    [SerializeField] private Build heroBuildFighter;
    [SerializeField] private Build heroBuildInterceptor;

    [SerializeField] private int heroPicker;
    [SerializeField] private Canvas canvasUI;
    [SerializeField] private Canvas backgroundCanvas;
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private GameObject heroObj;
    
    void OnEnable()
    {
        GameObject hero;
        Build choosenBuild;
        heroPicker = PlayerPrefs.GetInt("heroPicker");
        switch(heroPicker)
        {
            case 0:
                hero=Instantiate(heroObj, gameObject.transform);
                hero.GetComponent<HeroEntity>().Build(heroBuildFighter);
                choosenBuild = heroBuildFighter;
                break;
            case 1:
                hero=Instantiate(heroObj, gameObject.transform);
                hero.GetComponent<HeroEntity>().Build(heroBuildInterceptor);
                choosenBuild = heroBuildInterceptor;
                break;
            case 2:
                hero = Instantiate(heroObj, gameObject.transform);
                hero.GetComponent<HeroEntity>().Build(heroBuildSniper);
                choosenBuild = heroBuildSniper;
                break;
            default:
                hero = Instantiate(heroObj, gameObject.transform);
                hero.GetComponent<HeroEntity>().Build(heroBuildFighter);
                choosenBuild = heroBuildFighter;
                break;
        }
        /*canvasUI.worldCamera = hero.transform.GetChild(1).gameObject.GetComponent<Camera>();*/
        backgroundCanvas.worldCamera = hero.transform.GetChild(1).gameObject.GetComponent<Camera>();
        enemySpawner.Cam = hero.transform.GetChild(1).gameObject.GetComponent<Camera>();
        enemySpawner.Hero = hero;
    }
    
}
