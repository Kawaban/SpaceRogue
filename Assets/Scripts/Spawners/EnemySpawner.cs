using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private Build enemyInterceptorBuild;
    [SerializeField] private Build enemyFighterBuild;
    [SerializeField] private Build enemyHeavyCruiserBuild;
    private Camera cam;
    [SerializeField] private float secToGenerate;
    [SerializeField] private float delta;
    private GameObject hero;
    private Boolean generateCooldown = true;
    private int iterationOnLevel = 0;
    private int level = 0;
    [SerializeField] private TextAsset listOfEnemiesJSON;
    [SerializeField] private int iterationOnLevelMax;
    private int[][][] listOfAllGeneratedEnemies;
    public Camera Cam { get => cam; set => cam = value; }
    public GameObject Hero { get => hero; set => hero = value; }


    private class ListOfEnemiesData
    {
        public int[][][] array;
        
    }

    

     void Start()
    {
        ListOfEnemiesData listOf;
        try
        {
            Debug.Log(listOfEnemiesJSON.text);
            listOf = JsonConvert.DeserializeObject<ListOfEnemiesData>(listOfEnemiesJSON.text);
            if(listOf.array[0]==null)
            {
               /* Debug.Log("oH NO");*/
            }
     
            listOfAllGeneratedEnemies = listOf.array;
        }
        catch
        {
            Debug.LogError("File cannot be read");
            listOfAllGeneratedEnemies = new int[1][][];
            listOfAllGeneratedEnemies[0] = new int[1][];
            listOfAllGeneratedEnemies[0][0] = new int[1];
            listOfAllGeneratedEnemies[0][0][0] = 1;
        }
    }
    void FixedUpdate()
    {
        if (generateCooldown)
            GenerateEnemy();
    }

    private Boolean CheckToGenerate()
    {
        return gameObject.transform.childCount == 0;

    }

    private void GenerateEnemy()
    {
        int[] listOfEnemies = listOfAllGeneratedEnemies[Math.Min(level, listOfAllGeneratedEnemies.Length-1)][UnityEngine.Random.Range(0, listOfAllGeneratedEnemies[level].Length)];
        for(int i = 0; i < listOfEnemies.Length; i++)
        {
            Vector3 point = CalculatePoint();
            GameObject enemy = Instantiate(enemyObject, point, gameObject.transform.rotation);
            enemy.GetComponent<EnemyEntity>().Build(GetBuild(listOfEnemies[i]));
            enemy.transform.parent = gameObject.transform;
            EnemyShipController ehc = enemy.GetComponent<EnemyShipController>();
            ehc.Hero = hero;
        }
        iterationOnLevel++;
        if(iterationOnLevel >= iterationOnLevelMax)
        {
            iterationOnLevel = 0;
            level++;
        }
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

    private Build GetBuild(int param)
    {
        switch(param) 
        {
            case 0: return enemyInterceptorBuild;
            case 1: return enemyFighterBuild;
            case 2: return enemyHeavyCruiserBuild;
            default: return enemyInterceptorBuild;
        }
    }
}
