using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public Animator AnimatorRef;

    public NavMeshAgent ThisAgent;
    public GameObject SpawnedFrom;
    public GameObject ThisDestination;

    public bool LateRun = false;

    [System.NonSerialized]
    public bool IsCarrying = false;

    [SerializeField]
    public GameObject CarriedMat;

    [SerializeField]
    public bool IsRangedAttack;

    [SerializeField]
    public GameObject AttackObj;

    [SerializeField]
    public GameObject BulletOrigin;


    void Start()
    {
        FindObjectOfType<LevelStats>().GetComponent<LevelStats>().CurrentEnemies += 1;
        FindObjectOfType<LevelStats>().GetComponent<LevelStats>().EnemiesToSpawn -= 1;
        ThisAgent = GetComponent<NavMeshAgent>();
        ThisAgent.destination = ThisDestination.transform.position;
        //Debug.Log(ThisAgent.destination);
        //ThisDestination has already been assigned when the enemy was created.
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ThisDestination);
        //Debug.Log(ThisAgent.destination);
    }

    /*private void LateUpdate()
    {
        if (LateRun == false)
        {
            //When these lines are here, the guy spawns in the right spot, but doesn't move
            transform.position = SpawnedFrom.transform.position;
            ThisAgent.destination = EnemyDestination.DestinationPos;      //This is here so it will run last during the first update, which is needed for some reason. This if statement only runs once.
                //I don't get that line, I should change it to not reference EnemeyDestination directly, it should be EnemySpawner has a reference to EnemyDestination, and it shoves it in each enemy it creates
            LateRun = true;   
        }
    }*/

    public void AttackStart()
    {
        AnimatorRef.SetBool("InRange", true);
        ThisAgent.speed = 0;
        if (IsRangedAttack == false)
        {
            AnimatorRef.SetBool("Walk", false);
        }
    }

    public void AttackStop()
    {
        AnimatorRef.SetBool("InRange", false);
        AnimatorRef.SetBool("Walk", true);
    }

    public void NewDestination()
    {
        if (IsCarrying)
        {
            CarriedMat.SetActive(true);
        }
        ThisDestination = SpawnedFrom;
        ThisAgent.destination = ThisDestination.transform.position;
    }

    public void Attack()
    {
        //Debug.Log("EnAI " + ThisDestination + " " + ThisDestination.transform.position);
        GameObject NewBullet = Instantiate(AttackObj, BulletOrigin.transform.position, this.transform.rotation);
        NewBullet.GetComponent<BulletMove>().DestinationObj = ThisDestination;
    }
}
