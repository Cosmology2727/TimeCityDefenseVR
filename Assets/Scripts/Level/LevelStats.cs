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
    public int CurrrentWave;

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



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
