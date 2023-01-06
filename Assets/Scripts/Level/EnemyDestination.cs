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
    [SerializeField]
    public int EscapeesAllowed = 10;
    [SerializeField]
    public int MatsTakenAllowed = 10;

    [System.NonSerialized]
    public Vector3 SpawnedFrom;


    void Start()
    {
        //DestinationPos = GetComponent<Transform>().position;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("boop");
        //This if statement runs if it's a materials exit, and changes the enemy to return to it's origin.
        if (IsMats == true)
        {
            if (other.tag == "Enemy")
            {
                Debug.Log("boop2");
                //other.transform.root.GetComponent<EnemyAI>().ThisDestination = SpawnedFrom;
                other.transform.root.GetComponent<EnemyAI>().NewDestination();
            }

        }
    }
}
