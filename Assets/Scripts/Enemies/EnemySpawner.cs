using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Info probably isn't correct now
    //Takes a certain EnemyDestination as the destination for the enemies it spawns.
    //Takes the WaveStats for the current wave for THIS spawner, and then spawns what the WaveStats is requesting.


    [SerializeField]
    public GameObject ThisObj;

    [SerializeField]
    public GameObject ThisDestinationObj;
    [System.NonSerialized]
    public Vector3 ThisDestination;


    private void Start()
    {
        ThisDestination = ThisDestinationObj.transform.position;
    }

    void FixedUpdate()
    {
        /*
        HowMuchTime -= 1;
        if (HowMuchTime <= 0 && HowManyToSpawn >= 1)
        {
            HowManyToSpawn -= 1;
            HowMuchTime = TimeBetweenSpawns;
            var NewEnemy = Instantiate(Enemy01, transform.position, Quaternion.identity);
            //NewEnemy.transform.SetParent(ThisObj.transform);
            //NewEnemy.transform.position = NewEnemy.transform.parent.position; 
            NewEnemy.GetComponent<EnemyAI>().SpawnedFrom = ThisObj;
            NewEnemy.GetComponent<EnemyAI>().ThisDestination = ThisDestination;
        }*/
    }

    public void SpawnEnemy()
    {
        /*
        //test
        HowMuchTime = TimeBetweenSpawns;
        var NewEnemy = Instantiate(Enemy01, transform.position, Quaternion.identity);
        //NewEnemy.transform.SetParent(ThisObj.transform);
        //NewEnemy.transform.position = NewEnemy.transform.parent.position; 
        NewEnemy.GetComponent<EnemyAI>().SpawnedFrom = ThisObj;
        NewEnemy.GetComponent<EnemyAI>().ThisDestination = ThisDestination;*/
    }
}
