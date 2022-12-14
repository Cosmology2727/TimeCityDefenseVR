using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Weapons.Guns;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    public GameObject ThisObj;

    [SerializeField]
    public int EnemyHealth = 100;
    [SerializeField]
    public int EnemyArmor = 0;

    [SerializeField]
    public int EnemyDamage = 10;

    [SerializeField]
    public bool IsMech;

    [SerializeField]
    public GameObject DeathFX;

    [SerializeField]
    public GameObject BitsFX;



    void Start()
    {
        //EnemyHealth *= FindObjectOfType<ListVariables>().GetComponent<ListVariables>().Difficulty;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnDeath()
    {
        GameObject DeathVFX = Instantiate(DeathFX, this.transform.position, this.transform.rotation);
        DeathVFX.transform.localScale *= 1.2f;
        GameObject BitsVFX = Instantiate(BitsFX, this.transform.position, this.transform.rotation);
        Destroy(ThisObj);
    }
}
