using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private Build enemyBuild;
    private Camera cam;
    [SerializeField] private float secToGenerate;
    [SerializeField] private int numberOfGenerated;
    [SerializeField] private float delta;
    private GameObject hero;
    private Boolean generateCooldown = true;

    public Camera Cam { get => cam; set => cam = value; }
    public GameObject Hero { get => hero; set => hero = value; }

    void FixedUpdate()
    {
        if (CheckToGenerate() || generateCooldown)
            GenerateEnemy();
    }

    private Boolean CheckToGenerate()
    {
        return gameObject.transform.childCount == 0;

    }

    private void GenerateEnemy()
    {
        for(int i = 0; i < numberOfGenerated; i++)
        {
            Vector3 point = CalculatePoint();
            GameObject enemy = Instantiate(enemyObject, point, gameObject.transform.rotation);
            enemy.GetComponent<EnemyEntity>().Build(enemyBuild);
            enemy.transform.parent = gameObject.transform;
            EnemyShipController ehc = enemy.GetComponent<EnemyShipController>();
            ehc.Hero = hero;
        }
        if (generateCooldown)
            StartCoroutine(GenerationCooldown());
    }

    private Vector3 CalculatePoint()
    {
        Vector3 point = Cam.transform.parent.gameObject.transform.position;
        Debug.Log(point.x + " : " + point.y + " : ");
        float xsign = UnityEngine.Random.Range(0f, 1f);
        if (xsign > 0.5f)
            xsign = -1f;
        else
            xsign = 1f;

        float ysign = UnityEngine.Random.Range(0f, 1f);
        if (ysign > 0.5f)
            ysign = -1f;
        else
            ysign = 1f;
        Vector3 newpoint = new Vector3(point.x+xsign*(Cam.orthographicSize*Cam.aspect+UnityEngine.Random.Range(0f,delta)), point.y+ ysign * (Cam.orthographicSize + UnityEngine.Random.Range(0f, delta)), point.z);
        Debug.Log("L:"+newpoint.x + " : " + newpoint.y + " : ");
        return newpoint;
    }

    private IEnumerator GenerationCooldown()
    {
        generateCooldown = false;
        yield return new WaitForSeconds(secToGenerate);
        generateCooldown = true;
    }
}
