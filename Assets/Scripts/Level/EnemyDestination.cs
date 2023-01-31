using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    //Is attached to an end goal (exit, gate, or mats) to give the enemies of a specific EnemySpawner a destination.
    //Has the information about how this EnemyDestination is doing, how many exits have happened, and how many are allowed in total.

    public static Vector3 DestinationPos;


    [SerializeField]
    public bool IsGate = false;
    [SerializeField]
    public bool IsEscape = false;
    [SerializeField]
    public bool IsMats = false;
    [SerializeField]
    public float GateHealth = 1000;
    [System.NonSerialized] public bool IsGateDead = false;
    [SerializeField]
    public int EscapeesAllowed = 10;
    [SerializeField]
    public float TotalMats = 10;
    [System.NonSerialized]
    public float CurrentMats;
    [System.NonSerialized]
    public float PercentMats;

    [System.NonSerialized]
    public Vector3 SpawnedFrom;

    [SerializeField]
    public GameObject[] MatsObjs;
    private int WhileInt = 0;

    [SerializeField]
    public GameObject GateVisual;
    [SerializeField]
    public GameObject ExplodeGate;
    [SerializeField]
    public GameObject HitFX;


    void Start()
    {
        //DestinationPos = GetComponent<Transform>().position;
        CurrentMats = TotalMats;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("boop");
        //This if statement runs if it's a materials exit, and changes the enemy to return to it's origin.
        if (IsMats == true)
        {
            if (other.tag == "Enemy")
            {
                //Debug.Log(other.tag + " " + other.name);
                if (other.transform.root.GetComponent<EnemyAI>().IsCarrying == false)
                {
                    if (CurrentMats > 0)
                    {
                        other.transform.root.GetComponent<EnemyAI>().IsCarrying = true;
                        //Debug.Log("boop2");
                        //other.transform.root.GetComponent<EnemyAI>().ThisDestination = SpawnedFrom;
                        CurrentMats -= 1;
                        if (CurrentMats < 0)
                        {
                            CurrentMats = 0;
                        }
                        PercentMats = (CurrentMats / TotalMats) * 100;
                        //Debug.Log(CurrentMats + " " + TotalMats + " " + PercentMats);
                        while (WhileInt < TotalMats)
                        {
                            //Debug.Log(WhileInt + " " + PercentMats +" " + CurrentMats);
                            if ((PercentMats + 9) >= ((WhileInt + 1) * 10))
                            {
                                MatsObjs[WhileInt].SetActive(true);
                            }
                            else
                            {
                                MatsObjs[WhileInt].SetActive(false);
                            }
                            WhileInt += 1;
                        }
                    }
                    other.transform.root.GetComponent<EnemyAI>().NewDestination();
                    WhileInt = 0;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        
        if (IsGate == true)
        {
            if ((other.gameObject.tag == "EnemyBullet") && (IsGateDead == false))
            {
                GameObject NewHitFX = Instantiate(HitFX, other.transform.position, this.transform.rotation);
                //Debug.Log("yup");
                GateHealth -= other.transform.root.GetComponent<BulletMove>().BulletDamage;
                //Debug.Log("gate hit");
                if (GateHealth <= 0)
                {
                    IsGateDead = true;
                    //Debug.Log("gate dead");
                    GameObject NewExplosion = Instantiate(ExplodeGate, transform.position, this.transform.rotation);
                    NewExplosion.transform.localScale *= 5;
                    GateVisual.SetActive(false);
                }
                Destroy(other.transform.root.gameObject);
            }
        }
    }
}
