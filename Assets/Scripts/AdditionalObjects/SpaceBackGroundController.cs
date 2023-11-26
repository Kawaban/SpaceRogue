using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceBackGroundController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RawImage image;
    [SerializeField] private BackGroundHelper backGroundHelper;
    private float x, y;
    [SerializeField] private float drag;
    private void OnEnable()
    {
        if (backGroundHelper != null)
        {
            backGroundHelper.speedEventChange.AddListener(ChangeSpeed);
        }
        x = 0.01f;
        y = 0.01f;
    }

    public void ChangeSpeed(Pair<float, float> speed)
    {
        x=speed.first; y=speed.second;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        image.uvRect=new Rect(image.uvRect.position+new Vector2(x*drag,y*drag)*Time.deltaTime,image.uvRect.size);
    }
}
