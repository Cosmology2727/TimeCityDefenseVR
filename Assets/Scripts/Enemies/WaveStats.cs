using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStats : MonoBehaviour
{
    //Takes the LevelStats and applies it to THIS wave.
    //This goes on EACH enemey spawner, checks for current wave, then starts spawning THERE for what's needed for THIS wave.

    [System.NonSerialized]
    public LevelStats LevelStatsRef;

    [SerializeField]
    public int ThisWave;

    [SerializeField]
    public float TimeBetweenSpawns = 1f;

    [System.NonSerialized]
    public float HowMuchTime = 0f;

    [SerializeField]
    public GameObject EnemyType;

    [SerializeField]
    public int HowManyToSpawn = 0;
    [System.NonSerialized]
    public bool HasItSpawnedYet = false;


    [System.NonSerialized]
    public GameObject LevelStatsObj;

    [System.NonSerialized]
    public bool WaveGo = false;

    void Start()
    {
        LevelStatsRef = FindObjectOfType<LevelStats>().GetComponent<LevelStats>();
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
        if ((HowMuchTime <= 0) && (HowManyToSpawn >= 1) && WaveGo == true)
        {
            HowManyToSpawn -= 1;
            HowMuchTime = TimeBetweenSpawns;
            var NewEnemy = Instantiate(EnemyType, transform.position, Quaternion.identity);
            NewEnemy.GetComponent<EnemyAI>().SpawnedFrom = this.gameObject;
            NewEnemy.GetComponent<EnemyAI>().ThisDestination = gameObject.GetComponentInParent<EnemySpawner>().ThisDestinationObj;
        }
    }

    public void CheckWave(int CurrentWave)
    {
        if (ThisWave == CurrentWave)
        {
            if (HasItSpawnedYet == false)
            {
                LevelStatsRef.EnemiesToSpawn += HowManyToSpawn;
                WaveGo = true;
                //Debug.Log("wave checked" + ThisWave);
                HasItSpawnedYet = true;
            }
        }
    }
}
