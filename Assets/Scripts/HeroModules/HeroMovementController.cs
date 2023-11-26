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
}
