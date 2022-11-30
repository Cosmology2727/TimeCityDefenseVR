using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField]
    public int BulletDamage;
    public int ThisDamage;
    public int TempDamage;

    [SerializeField]
    public GameObject BloodSpurtObj;

    [SerializeField]
    public GameObject BloodObj;
    [SerializeField]
    public GameObject DustObj;
    [SerializeField]
    public GameObject SparksObj;

    [SerializeField]
    public GameObject ThisBullet;

    [SerializeField]
    public float range = 1000f;

    public Vector3 BulletDir;
    public Vector3 BulletDirDifference;
    public Vector3 BulletStartPos;
    public Vector3 BulletSecondPos;
    public Vector3 BulletRayStart;
    public int BulletTime = 0;

    public GameObject GunBack;
    public GameObject GunFront;

    public void Start()
    {
        transform.parent = null;

        GunBack = FindObjectOfType<GunDirection>().GetComponent<GunDirection>().GunBack;
        GunFront = FindObjectOfType<GunDirection>().GetComponent<GunDirection>().GunFront;
        BulletDir = GunFront.transform.position - GunBack.transform.position;

        this.GetComponent<Rigidbody>().velocity = BulletDir * 300;
    }

    /*public void Update()
    {
        BulletTime += 1;
        if (BulletTime == 1)
        {
            BulletStartPos = ThisBullet.GetComponent<Rigidbody>().transform.position;
        }
        else if (BulletTime == 2)
        {
            BulletSecondPos = ThisBullet.GetComponent<Rigidbody>().transform.position;
        }

        if (BulletTime > 1)
        {
            BulletDir = BulletSecondPos - BulletStartPos;
            //BulletDirDifference = BulletDir / 2;
            RaycastHit hit;
            BulletRayStart = ThisBullet.GetComponent<Rigidbody>().position;
            
            if (Physics.Raycast(BulletRayStart, BulletDir, out hit, range))
            {
                Debug.Log(hit.transform.name + " " + hit.transform.tag);
                GameObject NewBloodSpurt = Instantiate(BloodSpurtObj, hit.point, this.transform.rotation);
            }
        }
        if (BulletTime > 30)
        {
            //Destroy(ThisBullet);
        }


    }
    //*/

    public void OutputMessage()
    {
        Debug.Log("boop");
    }



    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision with " + other.gameObject.tag + " named " + other.transform.name);
        if (other.gameObject.tag == "Gun")
        {
            GameObject NewSparks = Instantiate(SparksObj, this.transform.position, this.transform.rotation);
        }
        else if (other.gameObject.tag == "Enemy") //Checks collision object to see if it's an enemy
        {
            GameObject NewBloodSpurt = Instantiate(BloodSpurtObj, this.transform.position, this.transform.rotation);

            /*if (other.gameObject.GetComponent<BodyPartId>() != null)
            {
                if (other.gameObject.GetComponent<BodyPartId>().Is01VeryWeak)
                {
                    ThisDamage = BulletDamage * 1;
                }
                if (other.gameObject.GetComponent<BodyPartId>().Is02Weak)
                {
                    ThisDamage = BulletDamage * 2;
                }
                if (other.gameObject.GetComponent<BodyPartId>().Is03Mild)
                {
                    ThisDamage = BulletDamage * 3;
                }
                if (other.gameObject.GetComponent<BodyPartId>().Is04Normal)
                {
                    ThisDamage = BulletDamage * 4;
                }
                if (other.gameObject.GetComponent<BodyPartId>().Is05Rough)
                {
                    ThisDamage = BulletDamage * 5;
                }
                if (other.gameObject.GetComponent<BodyPartId>().Is06Strong)
                {
                    ThisDamage = BulletDamage * 6;
                }
                if (other.gameObject.GetComponent<BodyPartId>().Is07VeryStrong)
                {
                    ThisDamage = BulletDamage * 100;
                }

                if (other.gameObject.GetComponent<BodyPartId>().EnemyStatsObj.GetComponent<EnemyStats>().EnemyArmor > 0)
                {
                    TempDamage = ThisDamage;
                    ThisDamage -= other.gameObject.GetComponent<BodyPartId>().EnemyStatsObj.GetComponent<EnemyStats>().EnemyArmor;
                    other.gameObject.GetComponent<BodyPartId>().EnemyStatsObj.GetComponent<EnemyStats>().EnemyArmor -= TempDamage;
                    GameObject NewDust = Instantiate(DustObj, this.transform.position, this.transform.rotation);
                }
                if (ThisDamage > 0)
                {
                    other.gameObject.GetComponent<BodyPartId>().EnemyStatsObj.GetComponent<EnemyStats>().EnemyHealth -= ThisDamage;
                    GameObject NewBlood = Instantiate(BloodObj, this.transform.position, this.transform.rotation);
                }
            }*/
            
        }
        else
        {
            GameObject NewDust = Instantiate(DustObj, this.transform.position, this.transform.rotation);
        }

        if (other.gameObject.tag == "Hat")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.transform.parent = null;
        }

        
        Destroy(ThisBullet);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");       
        if (other.gameObject.tag == "Enemy") //Checks collision object to see if it's an enemy
        {
            Debug.Log("2");
            Destroy(other.gameObject);
        }
        //Destroy(this);
    }*/
}
