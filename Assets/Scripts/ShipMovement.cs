using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxSpeed = 0.2f;
    [SerializeField] private float rotationSpeed=70f;
    [SerializeField] private float trustAcceleration = 10f;
    [SerializeField] private TextMeshProUGUI text;
    private float trust=0;
    private float angle = 0;
    private Rigidbody2D rb;
    Vector2 mousePos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 movement;
        movement.x=0;
        movement.y=maxSpeed*trust*Time.deltaTime;
        transform.Translate(movement);
        text.text = "debug" ;
        rb.rotation = angle; 
        
    }

    // Update is called once per frame
    void Update()
    {
        float modTrust = Input.GetAxisRaw("Vertical");
        trust += modTrust * trustAcceleration * Time.deltaTime;
        if (trust < 0)
            trust = 0;
        else if (trust > 100)
            trust = 100;

        float modAngle = -Input.GetAxisRaw("Horizontal");
        angle += modAngle * Time.deltaTime * rotationSpeed;
        if (angle < -180)
            angle += 360;
        else if (angle > 180)
            angle -= 360;

    }
}
