using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class HeroMovementController : MovementController
{
    // Start is called before the first frame update
    
    [SerializeField] private Camera cam;
    [SerializeField] private BackGroundHelper backGroundHelper;
    [SerializeField] private GameObject explosion;

    private Rigidbody2D rbcam;

   

    void OnEnable()
    {
        base.Rb = GetComponent<Rigidbody2D>();
        base.Shield = transform.GetChild(2).gameObject;
        rbcam = cam.GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
       base.FixedUpdateChange();
       rbcam.rotation = 0;
       backGroundHelper.SpeedChange(base.Trust * base.MovementData.MaxSpeed * Time.deltaTime * Mathf.Cos((base.Angle+90f) * Mathf.Deg2Rad), base.Trust * base.MovementData.MaxSpeed * Time.deltaTime*Mathf.Sin((base.Angle + 90f) * Mathf.Deg2Rad));
        
    }

    
    void Update()
    {
        float modTrust = Input.GetAxisRaw("Vertical");
        float modAngle = -Input.GetAxisRaw("Horizontal");
        base.UpdateChange(modAngle, modTrust);

    }

    public override void Death()
    {
        Debug.Log("GG");
        AudioController.Instance.Play(base.MovementData.ExplosionSound);
        GameObject explosionObj = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        explosionObj.transform.parent = gameObject.transform;
        explosionObj.transform.localScale = new Vector3(base.MovementData.ExplosionScale, base.MovementData.ExplosionScale, 1f);
        Destroy(explosionObj, 1f);
    }
}
