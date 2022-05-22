using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public bool possible;
    public int cooldown;
    public float a;
    public List<GameObject> currents = new List<GameObject>();
    public GameObject[] buttons;    

    public GameObject canv;

    void Start()
    {
        a = Mathf.FloorToInt(Time.time);
    }

    void Update()
    {
        //UnityEngine.Debug.Log(Time.deltaTime);
        a+=Time.deltaTime;
        if(a>cooldown)
        {
            a-=cooldown;
            //UnityEngine.Debug.Log(a);
            int randEnemy = Random.Range(0,enemyPrefabs.Length);
            int spawnPoint = Random.Range(0,spawnPoints.Length);

            currents.Add(Instantiate(enemyPrefabs[randEnemy],spawnPoints[spawnPoint].position,transform.rotation,canv.transform));
            //Class c = new Class();
            //currents.RemoveAt(0);
        }
    }
}