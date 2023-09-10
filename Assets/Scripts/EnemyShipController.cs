using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxSpeed = 0.2f;
    private float angle = 0;
    [SerializeField] private float rotationSpeed = 70f;
    private  Rigidbody2D rb;
    [SerializeField] private GameObject hero;
    private Boolean canAttack = true;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float bulletForce;
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 movement;
        movement.x = 0;
        movement.y = maxSpeed * Time.deltaTime;
        transform.Translate(movement);
        rb.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {

        float modAngle = FindHeroAngle();
        angle += modAngle * Time.deltaTime * rotationSpeed;
        if (angle < -180)
            angle += 360;
        else if (angle > 180)
            angle -= 360;
        
    }

    private float FindHeroAngle()
    {
        Rigidbody2D rbHero=hero.GetComponent<Rigidbody2D>();
        Vector2 lookDir = rbHero.position - rb.position;
        float targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90f;
        if (targetAngle < -180)
            targetAngle += 360;
        else if (targetAngle > 180)
            targetAngle -= 360;


        float fireDelta = 5f;
        if (Mathf.Abs(angle - targetAngle) < fireDelta && canAttack)
        {
            Shoot();
        }

        float delta = 1f;

        

        int forwardIndex1 = 0;
        int backwardIndex1 = 0;
        float localAngle = angle;
        for (int forwardIndex = 0; forwardIndex <= 360; forwardIndex++)
        {
            if (Mathf.Abs(localAngle - targetAngle) < delta)
            {
                forwardIndex1 = forwardIndex;
                break;
                
            }
            localAngle++;
            if (localAngle < -180)
                localAngle += 360;
            else if (localAngle > 180)
                localAngle -= 360;
        }
        localAngle = angle;
        for (int backwardIndex = 0; backwardIndex <= 360; backwardIndex++)
        {
            if (Mathf.Abs(localAngle - targetAngle) < delta)
            {
                backwardIndex1 = backwardIndex;
                break;
                
            }
            localAngle--;
            if (localAngle < -180)
                localAngle += 360;
            else if (localAngle > 180)
                localAngle -= 360;
        }


        if (forwardIndex1 > backwardIndex1)
            return -1f;
        else 
            return 1f;

       

    }
    private IEnumerator AttackCooldown()
    {
        canAttack = false;  
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(bulletForce * FirePoint.up, ForceMode2D.Impulse);
        bullet.transform.Rotate(0f, 0f, 90f);
        StartCoroutine(AttackCooldown());
    }

}
