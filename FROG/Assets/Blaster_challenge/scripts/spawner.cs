using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public bool possible;
    public int cooldown;
    public float a = 0f;//time sinc last spawn
    public List<GameObject> currents = new List<GameObject>();
    public GameObject[] buttons;    

    public GameObject canv;

    void Start()
    {
        a = 0f;
    }

    void Update()
    {
        if(Time.time - a > cooldown)
        {
            a = Time.time;
            int randEnemy = Random.Range(0,enemyPrefabs.Length);
            int spawnPoint = Random.Range(0,spawnPoints.Length);

            currents.Add(Instantiate(enemyPrefabs[randEnemy],spawnPoints[spawnPoint].position,transform.rotation,canv.transform));
        }
    }
}