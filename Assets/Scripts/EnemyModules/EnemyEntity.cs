using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    
   

    void OnEnable()
    {
        base.MovementController = GetComponent<EnemyShipController>();
        base.WeaponControll = GetComponent<EnemyWeaponController>();

    }
    void Start()
    {
        base.onStart();
    }

    void FixedUpdate()
    {
        base.onFixedUpdate();
    }


    public override void Death()
    {
        base.MovementController.Death();
        EnemyShipController enemyShipController = (EnemyShipController) base.MovementController;
        HeroEntity heroObj = enemyShipController.Hero.GetComponent<HeroEntity>();
        heroObj.IncreaseScore(base.EntityData.Score);
        Destroy(gameObject);
    }
}
