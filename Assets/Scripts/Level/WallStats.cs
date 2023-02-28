using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStats : MonoBehaviour
{
    [SerializeField]
    public CreateGrid CreateGridRef;
    
    [SerializeField]
    public bool IsMap;

    [SerializeField]
    public float CoordX;
    [SerializeField]
    public float CoordY;
    private int NewCoordX;
    private int NewCoordY;

    [SerializeField]
    public GameObject MapRef;
    [SerializeField]
    public GameObject LevelRef;

    [SerializeField]
    public int WallHeight;
    [SerializeField]
    public GameObject NWall;
    [SerializeField]
    public GameObject SWall;
    [SerializeField]
    public GameObject EWall;
    [SerializeField]
    public GameObject WWall;
    [SerializeField]
    public GameObject NEPillar;
    [SerializeField]
    public GameObject NWPillar;
    [SerializeField]
    public GameObject SEPillar;
    [SerializeField]
    public GameObject SWPillar;


    [SerializeField]
    public GameObject TowerSpawnSpot;


    private void Awake()
    {
        MapRef.GetComponent<MapTileStats>().WallHeight = WallHeight;
    }

    void Start()
    {
        //North check and fix
        NewCoordY = (int)CoordY + 1;
        Debug.Log(CreateGridRef.MapTileArray[(int)CoordX, NewCoordY].name);
        if (CreateGridRef.MapTileArray[(int)CoordX, NewCoordY].GetComponent<MapTileStats>().WallHeight == MapRef.GetComponent<MapTileStats>().WallHeight)
        {
            NWall.SetActive(false);
            CreateGridRef.MapTileArray[(int)CoordX, NewCoordY].GetComponent<MapTileStats>().WallOrOtherObj.GetComponent<WallStats>().SWall.SetActive(false);
            LevelRef.GetComponent<LevelTileStats>().WallOrOtherObj.GetComponent<WallStats>().NWall.SetActive(false);
            CreateGridRef.LevelTileArray[(int)CoordX, NewCoordY].GetComponent<LevelTileStats>().WallOrOtherObj.GetComponent<WallStats>().SWall.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
