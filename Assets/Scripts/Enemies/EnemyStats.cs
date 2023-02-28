using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Weapons.Guns;

public class EnemyStats : MonoBehaviour
{
    [System.NonSerialized]
    public LevelStats LevelStatsRef;
    [System.NonSerialized]
    public LevelMultipliers LevelMultipliersRef;

    [SerializeField]
    public GameObject ThisObj;

    [SerializeField]
    public int EnemyHealth = 100;
    [SerializeField]
    public int EnemyArmor = 0;

    [SerializeField]
    public int MatsEarned = 100;
    [SerializeField]
    public int EnergyEarned = 10;

    [SerializeField]
    public int EnemyDamage = 10;

    [SerializeField]
    public bool IsMech;

    [SerializeField]
    public GameObject DeathFX;

    [SerializeField]
    public GameObject BitsFX;

    [System.NonSerialized]
    public bool HasItRun = false;

    [System.NonSerialized]
    public bool IsDead = false;



    void Start()
    {
        if (HasItRun == false)
        {
            LevelStatsRef = FindObjectOfType<LevelStats>().GetComponent<LevelStats>();
            LevelMultipliersRef = FindObjectOfType<LevelMultipliers>().GetComponent<LevelMultipliers>();

            //Debug.Log("Enemy start before " + LevelStatsRef.CurrentEnemies + " " + LevelStatsRef.EnemiesToSpawn);
            LevelStatsRef.CurrentEnemies += 1;
            //Debug.Log("Enemy start after " + LevelStatsRef.CurrentEnemies + " " + LevelStatsRef.EnemiesToSpawn);
            LevelStatsRef.EnemiesToSpawn -= 1;
            //EnemyHealth *= FindObjectOfType<ListVariables>().GetComponent<ListVariables>().Difficulty;
            LevelStatsRef.UpdateText();

            HasItRun = true;
        }
    }

    
    public void OnDeath()
    {
        if (IsDead == false)
        {
            IsDead = true;
            //Debug.Log(LevelStatsRef.CurrentMats + " + " + MatsEarned + " = " + MatsEarned * LevelMultipliersRef.EarnedMatsMult + " " + Mathf.FloorToInt(MatsEarned * LevelMultipliersRef.EarnedMatsMult));
            LevelStatsRef.CurrentMats += Mathf.FloorToInt(MatsEarned * LevelMultipliersRef.EarnedMatsMult);
            LevelStatsRef.CurrentEnergy += Mathf.FloorToInt(EnergyEarned * LevelMultipliersRef.EarnedEnergyMult);
            LevelStatsRef.EnemiesKilled += 1;

            //Debug.Log("Enemy death before " + LevelStatsRef.CurrentEnemies + " " + LevelStatsRef.EnemiesToSpawn);
            LevelStatsRef.CurrentEnemies -= 1;
            //Debug.Log("Enemy death after " + LevelStatsRef.CurrentEnemies + " " + LevelStatsRef.EnemiesToSpawn);
            if ((LevelStatsRef.CurrentEnemies + LevelStatsRef.EnemiesToSpawn) <= 0)
            {
                LevelStatsRef.CurrentWave += 1;
                if (LevelStatsRef.CurrentWave > LevelStatsRef.TotalWaves)
                {
                    LevelStatsRef.TextCurrentWave.text = "WIN";
                }
            }
            LevelStatsRef.UpdateText();
            GameObject DeathVFX = Instantiate(DeathFX, this.transform.position, this.transform.rotation);
            DeathVFX.transform.localScale *= 1.2f;
            GameObject BitsVFX = Instantiate(BitsFX, this.transform.position, this.transform.rotation);
            Destroy(ThisObj);
        }
    }
}
