using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControll : MonoBehaviour
{
    private float damage;

    public float Damage { get => damage; set => damage = value; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        HeroEntity he = collision.transform.gameObject.GetComponent<HeroEntity>();
        if (he!=null)
        {
            he.calculateDamage(damage);
            Destroy(gameObject);
        }
        
    }


}
