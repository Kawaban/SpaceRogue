using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
    private float trust = 0;
    private float angle = 0;
    private Rigidbody2D rb;
    private MovementData movementData;
    private GameObject shield;
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public float Angle { get => angle;}
    public GameObject Shield { get => shield; set => shield = value; }
    public MovementData MovementData { get => movementData; set => movementData = value; }
    public float Trust { get => trust; }

    public void FixedUpdateChange()
    {
        Vector2 movement;
        movement.x = 0;
        movement.y = movementData.MaxSpeed * trust * Time.deltaTime;
        transform.Translate(movement);
        rb.rotation = angle;
    }

    public void UpdateChange(float modAngle, float modTrust)
    {
        angle += modAngle * Time.deltaTime * movementData.RotationSpeed;
        if (angle < -180)
            angle += 360;
        else if (angle > 180)
            angle -= 360;

        trust += modTrust * movementData.TrustAcceleration * Time.deltaTime;
        if (trust < 0)
            trust = 0;
        else if (trust > 100)
            trust = 100;

    }
    
    public virtual void Death()
    {

    }

    public void shieldEngage()
    {
       
        StartCoroutine(ShiledEffectCooldown());
    }

    public IEnumerator ShiledEffectCooldown()
    {
        if(MovementData.ShieldSound != null)
            AudioController.Instance.Play(MovementData.ShieldSound);
        shield.transform.Translate(new Vector3(0f, 0f, -1000f));
        yield return new WaitForSeconds(movementData.ShieldTime);
        shield.transform.Translate(new Vector3(0f, 0f, 1000f));
        
    }

    public void ApplyShipSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite=movementData.ShipSprite;
        gameObject.transform.localScale = new Vector3(movementData.Scale,movementData.Scale,1f);
    }
}
