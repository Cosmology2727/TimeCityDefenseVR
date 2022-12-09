using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    public static Vector3 DestinationPos;
    void Start()
    {
        DestinationPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
