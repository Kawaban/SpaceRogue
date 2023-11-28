using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroEntity : Entity
{
    [SerializeField] private UIScriptableObject UIObject;
    private Boolean isAlreadyDead = false;

    void OnEnable()
    {
        base.MovementController=GetComponent<HeroMovementController>();
        base.WeaponControll=gameObject.transform.GetChild(0).GetComponent<HeroWeaponController>();
        gameObject.transform.GetChild(0).GetComponent<HeroWeaponController>().UIObject = UIObject;
    }

    void Start()
    {
        base.onStart();
        UIObject.Init(base.EntityData.MaxShield, base.EntityData.MaxHealth);
       
    }

     void FixedUpdate()
    {
        base.onFixedUpdate();
        UIObject.ChangeShield(base.CurrentShield);
    }

    public override void calculateDamage(float damage)
    {
        base.calculateDamage(damage);
        UIObject.ChangeHealth(base.CurrentHealth);
        UIObject.ChangeShield(base.CurrentShield);
    }

    public override void Death()
    {
        if(!isAlreadyDead) 
        {
            isAlreadyDead = true;
            UIObject.DeathEvent(0);
            base.MovementController.Death();
        }
        
    }

    public void IncreaseScore(int score)
    {
        UIObject.ChangeScore(score);
    }
}
