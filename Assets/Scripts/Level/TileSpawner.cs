using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    public float CoordX;
    [SerializeField]
    public float CoordY;

    [SerializeField]
    public GameObject MapRef;
    [SerializeField]
    public GameObject LevelRef;

    [SerializeField]
    public GameObject ToSpawnObj;

    [SerializeField]
    public bool HasSpawned = false;
    [SerializeField]
    public bool SpawnButton = false;

    [System.NonSerialized]
    public Vector3 NewRot;

    [System.NonSerialized]
    public WallStats MapWallStatsRef;
    [System.NonSerialized]
    public WallStats LevelWallStatsRef;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HasSpawned == false && SpawnButton == true)
        {
            HasSpawned = true;
            var NewMapObj = Instantiate(ToSpawnObj, MapRef.transform.position, Quaternion.identity);
            NewRot = NewMapObj.transform.eulerAngles;
            NewRot.x += 90;
            NewRot.y += 180;
            NewMapObj.transform.localEulerAngles = NewRot;
            NewMapObj.transform.localScale = new Vector3 (0.02f, 0.02f, 0.02f);
            if (NewMapObj.GetComponent<WallStats>() != null)
            {
                MapRef.GetComponent<MapTileStats>().WallHeight = NewMapObj.GetComponent<WallStats>().WallHeight;
                MapWallStatsRef = NewMapObj.GetComponent<WallStats>();
                MapWallStatsRef.IsMap = true;
                MapWallStatsRef.CoordX = CoordX;
                MapWallStatsRef.CoordY = CoordY;
                MapWallStatsRef.MapRef = MapRef;
                MapWallStatsRef.LevelRef = LevelRef;
                MapRef.GetComponent<MapTileStats>().WallOrOtherObj = NewMapObj;
                MapWallStatsRef.CreateGridRef = MapRef.GetComponent<MapTileStats>().CreateGridRef.GetComponent<CreateGrid>();
            }

            var NewLevelObj = Instantiate(ToSpawnObj, LevelRef.transform.position, Quaternion.identity);
            NewRot = NewLevelObj.transform.eulerAngles;
            NewRot.y += 180;
            NewLevelObj.transform.localEulerAngles = NewRot;
            if (NewLevelObj.GetComponent<WallStats>() != null)
            {
                LevelRef.GetComponent<LevelTileStats>().WallHeight = NewLevelObj.GetComponent<WallStats>().WallHeight;
                LevelWallStatsRef = NewLevelObj.GetComponent<WallStats>();
                LevelWallStatsRef.IsMap = false;
                LevelWallStatsRef.CoordX = CoordX;
                LevelWallStatsRef.CoordY = CoordY;
                LevelWallStatsRef.MapRef = MapRef;
                LevelWallStatsRef.LevelRef = LevelRef;
                LevelWallStatsRef.CreateGridRef = MapRef.GetComponent<MapTileStats>().CreateGridRef.GetComponent<CreateGrid>();
            }
        }
    }
}
