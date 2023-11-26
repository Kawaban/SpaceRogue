using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponControll : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    private Transform FirePoint;
    private GameObject BulletPrefab;

    
    private Weapon weapon;

    private Boolean canAttack=true;


    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public Transform FirePoint1 { get => FirePoint; set => FirePoint = value; }
    public GameObject BulletPrefab1 { get => BulletPrefab; set => BulletPrefab = value; }
    public Weapon Weapon { get => weapon; set => weapon = value; }
    public bool CanAttack { get => canAttack; }

    public void Shoot()
    {
        if (canAttack)
        {
            StartCoroutine(Delay());
            StartCoroutine(AttackCooldown());
            if(Weapon.ShotSound!=null)
                AudioController.Instance.Play(Weapon.ShotSound);
        }

    }

    private IEnumerator AttackCooldown()
    {
       canAttack = false;
        yield return new WaitForSeconds(weapon.AttackCooldown);
       canAttack = true;
    }

    private void ShootSerie()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        EnemyBulletControll ebc = bullet.GetComponent<EnemyBulletControll>();
        BulletController bc = bullet.GetComponent<BulletController>();
        if (ebc != null)
            ebc.Damage = weapon.Damage;
        if (bc != null)
            bc.Damage = weapon.Damage;
        bulletRB.AddForce(weapon.BulletForce * FirePoint.up, ForceMode2D.Impulse);
        bullet.transform.Rotate(0f, 0f, 90f);
        Destroy(bullet, 10f);
    }

    private IEnumerator Delay()
    {
        for (int i = 0; i < weapon.Series; i++)
        {
            ShootSerie();
            yield return new WaitForSeconds(weapon.FireDelay);
        }
    }
}
