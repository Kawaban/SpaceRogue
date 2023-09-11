using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControll : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 mousePos;
    private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    public Transform FirePoint;
    public GameObject BulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

     void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        rb.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
          
    }

    private void Shoot()
    {
        GameObject bullet=Instantiate(BulletPrefab,FirePoint.position, FirePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(bulletForce*FirePoint.up,ForceMode2D.Impulse);
        bullet.transform.Rotate(0f, 0f, 90f);
        Destroy(bullet, 10f);
    }
}
