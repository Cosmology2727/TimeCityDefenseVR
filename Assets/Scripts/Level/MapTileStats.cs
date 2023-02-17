using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileStats : MonoBehaviour
{
    [SerializeField]
    public float CoordX;
    [SerializeField]
    public float CoordZ;

    [SerializeField]
    public GameObject LevelRef;

    [System.NonSerialized]
    public GameObject CurrentTower;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
