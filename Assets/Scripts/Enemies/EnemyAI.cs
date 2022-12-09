using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent ThisAgent;
    public GameObject SpawnedFrom;
    public GameObject ThisDestination;

    public bool LateRun = false;

    void Start()
    {
        ThisAgent = GetComponent<NavMeshAgent>();

        Debug.Log(ThisAgent.destination);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (LateRun == false)
        {
            //When these lines are here, the guy spawns in the right spot, but doesn't move
            transform.position = SpawnedFrom.transform.position;
            ThisAgent.destination = EnemyDestination.DestinationPos;

            LateRun = true;
        }


    }
}
