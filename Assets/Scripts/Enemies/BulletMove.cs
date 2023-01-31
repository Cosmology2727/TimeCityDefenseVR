using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    public float BulletDamage;

    [System.NonSerialized]
    public GameObject DestinationObj;
    [System.NonSerialized]
    public Vector3 DebugV3;
    [System.NonSerialized]
    public float DebugFloat;

    [SerializeField]
    public float BulletSpeed;

    [System.NonSerialized]
    public Vector3 BulletDir;

    [System.NonSerialized]
    public Vector3 DestinationPos;

    void Start()
    {
        //Debug.Log("BuMo  " + DestinationObj + " " + DestinationObj.transform.position);
        //DebugV3 = DestinationObj.transform.position;
        //DebugV3.y += 2;
        //Debug.DrawLine(DestinationObj.transform.position, DebugV3);
        DestinationPos = DestinationObj.transform.position;
        DestinationPos.y += 3;
        BulletDir = DestinationPos - transform.position;
        //Debug.DrawLine(transform.position, DestinationPos, Color.yellow,9999999999,false);
        //Debug.DrawRay(transform.position, BulletDir, Color.yellow, 99999999, false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);

        transform.Translate(BulletDir * BulletSpeed * Time.deltaTime, Space.World);
    }
}
