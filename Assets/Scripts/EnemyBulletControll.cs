using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControll : MonoBehaviour
{
    private GameObject shield;
    [SerializeField] private float time=1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            shield = collision.transform.GetChild(2).gameObject;
            if (shield.name == "shield_Edit")           
                StartCoroutine("ShiledEffectCooldown");
   
        }
    }

    private IEnumerator ShiledEffectCooldown()
    {
        shield.transform.Translate(new Vector3(0f, 0f, -1000f));
        gameObject.transform.Translate(new Vector3(0f, 0f, 1000f));
        yield return new WaitForSeconds(time);
        shield.transform.Translate(new Vector3(0f, 0f, 1000f));
        Destroy(gameObject);
    }

}
