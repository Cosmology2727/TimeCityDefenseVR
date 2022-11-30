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
    public GameObject BloodSpurtObj;

    [SerializeField]
    public int BulletDamage = 10;
    public int ThisDamage;
    public int TempDamage;

    public Quaternion NowRot;



    private void Start()
    {
        TimeToDeath = 5000;
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
            NowRot.x = ThisRigid.velocity.x;
            NowRot.y = ThisRigid.velocity.y;
            NowRot.z = ThisRigid.velocity.z;

            Debug.Log(ThisRigid.velocity);

            //transform.localEulerAngles = this.transform.forward;          //Kind of almost works, it seems to always be zeroing out?
            //transform.localEulerAngles = ThisRigid.velocity;              //Kind of almost works
            //ThisRigid.transform.eulerAngles = NowRot.eulerAngles;         //Didn't work, wouldn't rotate and broke stuff
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (InAir)
        {
            //Debug.Log("collision of " + other.gameObject.tag);
        }

        if (other.gameObject.tag == "StickyObj" && InAir)
        {
            ThisRigid.constraints = RigidbodyConstraints.FreezeAll; 
            ArrowVector = ThisRigid.velocity;
            InAir = false;
            //ThisArrow.transform.parent = other.transform;                 //For some reason this was changing the rotation of the arrow
        }

        if (other.gameObject.tag == "Enemy" && InAir) //Checks collision object to see if it's an enemy
        {
            GameObject NewBloodSpurt = Instantiate(BloodSpurtObj, this.transform.position, this.transform.rotation);

            
        }

        if (other.gameObject.tag == "Hat")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.transform.parent = null;
            InAir = false;
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag != "Enemy" && InAir)
        {
            InAir = false;
        }
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
