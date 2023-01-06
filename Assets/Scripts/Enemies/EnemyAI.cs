using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent ThisAgent;
    public Vector3 SpawnedFrom;
    public Vector3 ThisDestination;

    public bool LateRun = false;

    void Start()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
        ThisAgent.destination = ThisDestination;
        //Debug.Log(ThisAgent.destination);
        //ThisDestination has already been assigned when the enemy was created.
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ThisDestination);
        Debug.Log(ThisAgent.destination);
    }

    private void LateUpdate()
    {
        if (LateRun == false)
        {
            /*
            //When these lines are here, the guy spawns in the right spot, but doesn't move
            transform.position = SpawnedFrom.transform.position;
            ThisAgent.destination = EnemyDestination.DestinationPos;      //This is here so it will run last during the first update, which is needed for some reason. This if statement only runs once.
                //I don't get that line, I should change it to not reference EnemeyDestination directly, it should be EnemySpawner has a reference to EnemyDestination, and it shoves it in each enemy it creates
            LateRun = true;
            */
        }


    }

    public void NewDestination()
    {
        ThisDestination = SpawnedFrom;
        ThisAgent.destination = ThisDestination;
    }

}
