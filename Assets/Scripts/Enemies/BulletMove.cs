using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [System.NonSerialized]
    public Vector3 DestinationObj;

    [SerializeField]
    public float BulletSpeed;

    [System.NonSerialized]
    public Vector3 BulletDir;

    void Start()
    {
        Debug.Log(DestinationObj);
        DestinationObj.y += 2;
        BulletDir = DestinationObj - transform.position;
        Debug.Log(BulletDir);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);

        transform.Translate(BulletDir * BulletSpeed * Time.deltaTime);
    }
}
