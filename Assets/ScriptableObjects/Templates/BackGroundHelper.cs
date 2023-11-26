using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
[CreateAssetMenu(menuName = "ScriptableObjects/BackGroundHelper")]
public class BackGroundHelper : ScriptableObject
{
    // Start is called before the first frame update
    private float speed_x;
    private float speed_y;
    [System.NonSerialized] public UnityEvent<Pair<float,float>> speedEventChange;
    private void OnEnable()
    {
        speed_x = 0; speed_y = 0;
        if (speedEventChange == null)
            speedEventChange = new UnityEvent<Pair<float, float>>();
    }

    public void SpeedChange(float newspeed_x,float newspeed_y)
    {
        speed_x = newspeed_x; speed_y=newspeed_y;
        speedEventChange.Invoke(new Pair<float, float> (speed_x,speed_y));
    }
}
