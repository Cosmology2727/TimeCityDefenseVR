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
    [SerializeField]
    public GameObject CreateGridRef;

    [SerializeField]
    public int WallHeight;
    [SerializeField]
    public GameObject WallOrOtherObj;
    [SerializeField]
    public GameObject TowerOrStairsObj;
}
