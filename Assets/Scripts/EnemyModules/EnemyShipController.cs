using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class EnemyShipController : MovementController
{
    // Start is called before the first frame update
    
    private GameObject hero;
    [SerializeField] private EnemyWeaponController weaponController;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float explosionTime;
    public GameObject Hero { get => hero; set => hero = value; }
   

    void OnEnable()
    {
        
        base.Rb = GetComponent<Rigidbody2D>();
        base.Shield = transform.GetChild(1).gameObject;
    }
    void FixedUpdate()
    {
        base.FixedUpdateChange();
    }

    // Update is called once per frame
    void Update()
    {

        float modAngle = FindHeroAngle();
        base.UpdateChange(modAngle, 1f);
        
    }

    private float FindHeroAngle()
    {
        Rigidbody2D rbHero=hero.GetComponent<Rigidbody2D>();
        Vector2 lookDir = rbHero.position - base.Rb.position;
        float targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90f;
        if (targetAngle < -180)
            targetAngle += 360;
        else if (targetAngle > 180)
            targetAngle -= 360;


        float fireDelta = 5f;
        if (Mathf.Abs(base.Angle - targetAngle) < fireDelta )
        {
            weaponController.Shoot();
        }

        float delta = 1f;

        

        int forwardIndex1 = 0;
        int backwardIndex1 = 0;
        float localAngle = base.Angle;
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
        localAngle = base.Angle;
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

    public override void Death()
    {
       
        GameObject explosionObj = Instantiate(explosion, gameObject.transform.position,Quaternion.identity);
        AudioController.Instance.Play(base.MovementData.ExplosionSound);
        Destroy(explosionObj, explosionTime);
    }
  


}
