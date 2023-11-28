using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "ScriptableObjects/UIObject")]
public class UIScriptableObject : ScriptableObject
{
    private float currentHealth;
    private float currentShield;
    private float maxHealth;
    private float maxShield;
    private int score=0;
    private float reload = 0f;
    
    [System.NonSerialized] public UnityEvent<float> healthEventChange;
    [System.NonSerialized] public UnityEvent<float> shieldEventChange;
    [System.NonSerialized] public UnityEvent<Pair<Boolean, float>> reloadEventChange;
    [System.NonSerialized] public UnityEvent<int> scoreEventChange;
    [System.NonSerialized] public UnityEvent<int> deathEvent;

    public int Score { get => score; }

    private void OnEnable()
    {
        score = 0;
        reload = 0f;
        if ( healthEventChange == null)
            healthEventChange = new UnityEvent<float>();
        if (shieldEventChange == null)
            shieldEventChange = new UnityEvent<float>();
        if (reloadEventChange == null)
            reloadEventChange = new UnityEvent<Pair<Boolean, float>>();
        if (scoreEventChange == null)
            scoreEventChange = new UnityEvent<int>();
        if (deathEvent == null)
            deathEvent = new UnityEvent<int>();
    }

    public void Refresh()
    {
        OnEnable();
    }

    public void Init(float maxShield, float maxHealth)
    {
        this.maxShield = maxShield;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.currentShield = maxShield;
    }

    public void ChangeShield(float value)
    {
        currentShield = value;
        shieldEventChange.Invoke(currentShield / maxShield);
    }
    public void ChangeHealth(float value)
    {
        currentHealth = value;
        healthEventChange.Invoke(currentHealth / maxHealth);
    }
    public void ChangeReload(Pair<Boolean,float> value)
    {
        if (value.first)
            reload = 0f;
        else
            reload += value.second;
        reloadEventChange.Invoke(new Pair<Boolean, float>(value.first,reload));
    }
    public void ChangeScore(int value)
    {
        score += value;
        scoreEventChange.Invoke(score);
    }

    public void DeathEvent(int value)
    {
        deathEvent.Invoke(value);
    }

}
