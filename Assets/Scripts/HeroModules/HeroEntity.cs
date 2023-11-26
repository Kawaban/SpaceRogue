using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroEntity : Entity
{
    [SerializeField] private UIScriptableObject UIObject;
    

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
        /*gameObject.transform.GetChild(1).gameObject.GetComponent<Camera>().transform.Translate(new Vector3(0f, 0f, 2000f));*/
        UIObject.DeathEvent(0);
    }

    public void IncreaseScore(int score)
    {
        UIObject.ChangeScore(score);
    }
}
