using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy01;
    [SerializeField]
    public GameObject Enemy02;
    [SerializeField]
    public GameObject Enemy03;
    [SerializeField]
    public GameObject Enemy04;
    [SerializeField]
    public GameObject Enemy05;

    [SerializeField]
    public float TimeBetweenSpawns;
    [System.NonSerialized]
    public float HowMuchTime;

    [SerializeField]
    public bool IsInfinite;

    [SerializeField]
    public int HowManyToSpawn;

    [SerializeField]
    public GameObject ThisObj;

    [SerializeField]
    public GameObject ThisDestination;


    private void Start()
    {
        TimeBetweenSpawns *= 50; //Makes whatever it is into seconds
        HowMuchTime = TimeBetweenSpawns;
    }

    void FixedUpdate()
    {
        HowMuchTime -= 1;
        if (HowMuchTime <= 0)
        {
            if (IsInfinite)
            {
                SpawnEnemy();
            }
            else if (HowManyToSpawn > 0)
            {
                HowManyToSpawn -= 1;
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        //test
        HowMuchTime = TimeBetweenSpawns;
        var NewEnemy = Instantiate(Enemy01, transform.position, Quaternion.identity);
        //NewEnemy.transform.SetParent(ThisObj.transform);
        //NewEnemy.transform.position = NewEnemy.transform.parent.position; 
        NewEnemy.GetComponent<EnemyAI>().SpawnedFrom = ThisObj;
        NewEnemy.GetComponent<EnemyAI>().ThisDestination = ThisDestination;
    }
}
