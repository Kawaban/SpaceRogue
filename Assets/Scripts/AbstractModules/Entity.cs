using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private MovementController movementController;
    private WeaponControll weaponControll;
    private EntityData entityData;

    public MovementController MovementController { get => movementController; set => movementController = value; }
    public WeaponControll WeaponControll { get => weaponControll; set => weaponControll = value; }
    public EntityData EntityData { get => entityData; set => entityData = value; }
    public float CurrentHealth { get => currentHealth;}
    public float CurrentShield { get => currentShield;}

    private float currentHealth;
    private float currentShield;
    public virtual void calculateDamage(float damage)
    {
        if(currentShield > 0)
        {
            movementController.shieldEngage();
            currentShield -= damage;
            if(currentShield < 0 )
            {
                currentHealth += currentShield;
                currentShield = 0;
                
            }
        }
        else
           currentHealth -= damage;

        if(currentHealth <= 0)
            Death();
            
            
    }

    protected void onStart()
    {
        currentHealth = EntityData.MaxHealth;
        currentShield = EntityData.MaxShield;
    }

    protected void onFixedUpdate()
    {
        regenerateShiled();
    }
    private void regenerateShiled()
    {
        currentShield += entityData.ShieldRegeneration *Time.deltaTime;
        if (currentShield > entityData.MaxShield)
            currentShield = entityData.MaxShield;
    }

    

    public virtual void Death()
    {
        
    }

    public void Build(Build build)
    {
        entityData=build.EntityData;
        movementController.MovementData=build.MovementData;
        weaponControll.Weapon = build.Weapon;
        movementController.ApplyShipSprite();
    }
    






}
