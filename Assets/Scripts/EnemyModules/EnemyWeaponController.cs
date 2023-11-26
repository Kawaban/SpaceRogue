using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponControll
{
    
   

    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject BulletPrefab;
    

    void OnEnable()
    {
        base.Rb = GetComponent<Rigidbody2D>();
        base.FirePoint1 = FirePoint;
        base.BulletPrefab1 = BulletPrefab;
        
        
    }

   




}
