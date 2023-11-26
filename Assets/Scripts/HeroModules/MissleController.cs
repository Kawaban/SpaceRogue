using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    // Start is called before the first frame update
    private float damage = 0;
    public float Damage { get => damage; set => damage = value; }
    public GameObject Target { get => target; set => target = value; }

    private GameObject target;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private float angle = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        Vector2 movement;
        movement.x = 0;
        movement.y = speed * Time.deltaTime;
        transform.Translate(movement);
        rb.rotation = angle;

    }
    void Update()
    {
        float modAngle=FindTargetAngle();
        angle += modAngle * Time.deltaTime * rotationSpeed;
        if (angle < -180)
            angle += 360;
        else if (angle > 180)
            angle -= 360;
    }
    private float FindTargetAngle()
    {
        Rigidbody2D rbHero = target.GetComponent<Rigidbody2D>();
        Vector2 lookDir = rbHero.position - rb.position;
        float targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if (targetAngle < -180)
            targetAngle += 360;
        else if (targetAngle > 180)
            targetAngle -= 360;
        

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
