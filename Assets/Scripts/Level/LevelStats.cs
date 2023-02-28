using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelStats : MonoBehaviour
{
    //Takes the CityModifications and applies it to the specifics for this level

    [SerializeField]
    public int NumberOfWaves; //This is how many waves the level itself has, before modifiers

    //[System.NonSerialized]
    public int TotalWaves; //This is the TOTAL amount of waves, after all modifiers
    //[System.NonSerialized]
    public int CurrentWave = 1;

    [System.NonSerialized]
    public int CurrentMats = 0;
    [System.NonSerialized]
    public int CurrentEnergy = 0;

    //[System.NonSerialized]
    public int CurrentEnemies = 0;
    //[System.NonSerialized]
    public int EnemiesToSpawn = 0;
    //[System.NonSerialized]
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


    [System.NonSerialized]
    public int LeftGoal1;
    [System.NonSerialized]
    public int LeftGoal2;
    [System.NonSerialized]
    public int LeftGoal3;
    [System.NonSerialized]
    public int LeftGoal4;
    [System.NonSerialized]
    public int LeftGoal5;

    [SerializeField]
    public TextMeshProUGUI TextGoal1;
    [SerializeField]
    public TextMeshProUGUI TextGoal2;
    [SerializeField]
    public TextMeshProUGUI TextGoal3;
    [SerializeField]
    public TextMeshProUGUI TextGoal4;
    [SerializeField]
    public TextMeshProUGUI TextGoal5;

    [SerializeField]
    public TextMeshProUGUI TextMats;
    [SerializeField]
    public TextMeshProUGUI TextEnergy;
    [SerializeField]
    public TextMeshProUGUI TextCurrentWave;
    [SerializeField]
    public TextMeshProUGUI TextCurrentEnemies;
    [SerializeField]
    public TextMeshProUGUI TextEnemiesToSpawn;


    void Start()
    {
        WaveStatsRefs = GameObject.FindObjectsOfType<WaveStats>();
        //NewWave();

        //TextGoal1.text = 

        TotalWaves = NumberOfWaves;
        

        TextCurrentWave.text = "Wave: " + CurrentWave;

        CurrentMats = 0;
        TextMats.text = "" + CurrentMats;
        CurrentEnergy = 0;
        TextEnergy.text = "" + CurrentEnergy;
        TextCurrentEnemies.text = "" + CurrentEnemies;
        TextEnemiesToSpawn.text = "" + EnemiesToSpawn;

        //NewWave();
    }

    public void UpdateText()
    {
        TextMats.text = "" + CurrentMats;
        TextEnergy.text = "" + CurrentEnergy;
        TextCurrentEnemies.text = "Current " + CurrentEnemies;
        TextEnemiesToSpawn.text = "Left " + EnemiesToSpawn;
        if (CurrentWave > TotalWaves)
        {
            TextCurrentWave.text = "Win";
        }
        else
        {
            TextCurrentWave.text = "Wave: " + CurrentWave;
        }
    }

    public void NewWave()
    {
        //Debug.Log("pushed");
        //Debug.Log("New Wave " + CurrentEnemies + " " + EnemiesToSpawn);
        if (CurrentEnemies <= 0)
        {
            if (EnemiesToSpawn <= 0)
            {
                //Debug.Log("inside New Wave if " + CurrentEnemies + " " + EnemiesToSpawn);
                for (int i = 0; i < WaveStatsRefs.Length; i++)
                {
                    WaveStatsRefs[i].CheckWave(CurrentWave);
                }
            }
        }
        //Debug.Log("after New Wave if " + CurrentEnemies + " " + EnemiesToSpawn);
    }
}
