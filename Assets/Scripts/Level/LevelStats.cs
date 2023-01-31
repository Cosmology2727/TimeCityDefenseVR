using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    //Takes the CityModifications and applies it to the specifics for this level

    [SerializeField]
    public int NumberOfWaves;

    [System.NonSerialized]
    public int TotalWaves;
    [System.NonSerialized]
    public int CurrentWave = 1;

    [System.NonSerialized]
    public int CurrentEnemies = 0;
    [System.NonSerialized]
    public int EnemiesToSpawn = 0;
    [System.NonSerialized]
    public int EnemiesKilled = 0;

    [SerializeField]
    public GameObject[] WaveObjs;


    [SerializeField]
    public GameObject EnemySpawner1;
    [SerializeField]
    public GameObject EnemySpawner2;
    [SerializeField]
    public GameObject EnemySpawner3;
    [SerializeField]
    public GameObject EnemySpawner4;
    [SerializeField]
    public GameObject EnemySpawner5;
    [SerializeField]
    public GameObject EnemySpawner6;
    [SerializeField]
    public GameObject EnemySpawner7;
    [SerializeField]
    public GameObject EnemySpawner8;

    public WaveStats[] WaveStatsRefs;


    void Start()
    {
        WaveStatsRefs = GameObject.FindObjectsOfType<WaveStats>();
        NewWave();

    }

    void Update()
    {
        
    }

    public void NewWave()
    {
            WaveStatsRefs[CurrentWave].CheckWave();
        


    }
}
