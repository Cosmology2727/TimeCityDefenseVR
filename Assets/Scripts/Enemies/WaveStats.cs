using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStats : MonoBehaviour
{
    //Takes the LevelStats and applies it to THIS wave.
    //This goes on EACH enemey spawner, checks for current wave, then starts spawning THERE for what's needed for THIS wave.

    [SerializeField]
    public int ThisWave;

    [SerializeField]
    public float TimeBetweenSpawns = 1f;

    [System.NonSerialized]
    public float HowMuchTime = 0f;

    [SerializeField]
    public GameObject EnemyType;

    [SerializeField]
    public int HowManyToSpawn = 10;


    [System.NonSerialized]
    public GameObject LevelStatsObj;

    void Start()
    {
        //Debug.Log(TimeBetweenSpawns);
        LevelStatsObj = FindObjectOfType<LevelStats>().GetComponent<GameObject>();
        //TimeBetweenSpawns *= 1; //Makes whatever it is into seconds, not needed because I'm subtracting time.deltatime now
        //Debug.Log(TimeBetweenSpawns);
        HowMuchTime = TimeBetweenSpawns;
        //this.GetComponent<EnemySpawner>().ThisDestination.GetComponent<EnemyDestination>().SpawnedFrom = this.gameObject;   //Should go into the EnemySpawner script, get the destination of all waves, and the destination has a variable to show where the enemies came from (in case they carry back materials), and it makes that variable THIS object, which is the location the enemies spawned from
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(HowMuchTime);
        HowMuchTime -= 1 * Time.deltaTime;
        if (HowMuchTime <= 0 && HowManyToSpawn >= 1)
        {
            HowManyToSpawn -= 1;
            HowMuchTime = TimeBetweenSpawns;
            var NewEnemy = Instantiate(EnemyType, transform.position, Quaternion.identity);
            //NewEnemy.transform.SetParent(ThisObj.transform);
            //NewEnemy.transform.position = NewEnemy.transform.parent.position; 
            NewEnemy.GetComponent<EnemyAI>().SpawnedFrom = this.transform.position;
            NewEnemy.GetComponent<EnemyAI>().ThisDestination = GetComponent<EnemySpawner>().ThisDestination;
        }
    }

}
