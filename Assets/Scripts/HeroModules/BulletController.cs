using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    private float damage=0;
    public float Damage { get => damage; set => damage = value; }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        EnemyEntity he = collision.transform.gameObject.GetComponent<EnemyEntity>();
        if (he != null)
        {
            he.calculateDamage(damage);
            Destroy(gameObject);
        }

    }

}
