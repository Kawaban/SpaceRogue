using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControll : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
            Destroy(gameObject);
    }
}
