using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    [SerializeField]
    GameObject ThisArrow;

    bool InAir = true;

    int TimeToDeath = 600;

    public Rigidbody ThisRigid;

    public Vector3 ArrowVector;

    [SerializeField]
    public GameObject BloodObj;
    [SerializeField]
    public GameObject SparksObj;
    [SerializeField]
    public GameObject DustObj;



    [SerializeField]
    public int ArrowDamage = 50;
    public int ThisDamage;
    public int TempDamage;

    public Quaternion NowRot;



    private void Start()
    {
        //TimeToDeath = 5000;
        ThisRigid = GetComponent<Rigidbody>();
        InAir = true;
    }

    void Update()
    {
        TimeToDeath -= 1;
        if (TimeToDeath < 1)
        {
            Destroy(ThisArrow);
        }
        if (InAir)
        {
            NowRot.x = ThisRigid.velocity.x;        //This stuff is pointless I believe, from an earlier attempt at stuff
            NowRot.y = ThisRigid.velocity.y;
            NowRot.z = ThisRigid.velocity.z;
            //Debug.Log(ThisRigid.velocity);
            //transform.localEulerAngles = this.transform.forward;          //Kind of almost works, it seems to always be zeroing out?
            //transform.localEulerAngles = ThisRigid.velocity;              //Kind of almost works
            //ThisRigid.transform.eulerAngles = NowRot.eulerAngles;         //Didn't work, wouldn't rotate and broke stuff
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Enemy" && InAir) //Checks collision object to see if it's an enemy
        {
            Destroy(ThisArrow);
            other.gameObject.GetComponent<EnemyAI>().AnimatorRef.Play("Armature_Armature_001_Armature_WalkDamaged");

            if (other.gameObject.GetComponent<EnemyStats>().IsMech == false)
            {
                GameObject NewVFX = Instantiate(BloodObj, this.transform.position, this.transform.rotation);
            }
            else if (other.gameObject.GetComponent<EnemyStats>().IsMech == true)
            {
                GameObject NewVFX = Instantiate(SparksObj, this.transform.position, this.transform.rotation);
            }


            other.gameObject.GetComponent<EnemyStats>().EnemyHealth -= ArrowDamage;
            //Debug.Log(other.gameObject.GetComponent<EnemyStats>().EnemyHealth);

            if (other.gameObject.GetComponent<EnemyStats>().EnemyHealth <= 0)
            {
                other.gameObject.GetComponent<EnemyStats>().OnDeath();
            }
        }


        else if (other.gameObject.tag != "Enemy" && InAir)
        {
            InAir = false;
            GameObject NewVFX = Instantiate(DustObj, this.transform.position, this.transform.rotation);
            Destroy(ThisArrow);
        }

        /*if (InAir)        //The goal was to make the arrow stick, but the math is stupid
        {
            ThisRigid.constraints = RigidbodyConstraints.FreezeAll;
            ArrowVector = ThisRigid.velocity;
            InAir = false;
            //ThisArrow.transform.parent = other.transform;                 //For some reason this was changing the rotation of the arrow, PROBABLY because it's taking the local rotation into account
            //this.transform.rotation = this.transform.rotation * Quaternion.Inverse(other.transform.rotation);
            //Debug.Log("collision of " + other.gameObject.tag);
        }*/

        /*if (other.gameObject.tag == "Hat")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.transform.parent = null;
            InAir = false;
            Destroy(other.gameObject);
        }*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.gameObject.tag == "Enemy") //Checks collision object to see if it's an enemy
        {
            Debug.Log("2");
            Destroy(other.gameObject);

        }
    }*/
    }
