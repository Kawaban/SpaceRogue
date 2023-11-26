using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWeaponController : WeaponControll
{
    private Vector2 mousePos;
    private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject BulletPrefab;

    public UIScriptableObject UIObject;

    void OnEnable()
    {
        base.Rb = GetComponent<Rigidbody2D>();
        base.FirePoint1 = FirePoint;
        base.BulletPrefab1 = BulletPrefab;
        rb = GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            base.Shoot();
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (base.Weapon.CanTurn)
        {
            Vector2 lookDir = mousePos - rb.position;
            rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        }
        else
        {
            rb.rotation=gameObject.transform.parent.gameObject.GetComponent<HeroMovementController>().Angle+90f;
        }

        UIObject.ChangeReload(new Pair<Boolean, float>(base.CanAttack, Time.deltaTime / base.Weapon.AttackCooldown));

    }

    private void LaunchRocket()
    {

    }

    
}
