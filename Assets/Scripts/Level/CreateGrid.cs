using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class CreateGrid : MonoBehaviour
{
    [SerializeField]
    public bool EnableRunning = false;
    [SerializeField]
    public bool CreationDone = false;

    [System.NonSerialized]
    public int MaxX = 25;
    [System.NonSerialized]
    public int MaxY = 18;
    [System.NonSerialized]
    public float CurrentX;
    [System.NonSerialized]
    public float CurrentY;
    [System.NonSerialized]
    public Vector3 CurrentPos;

    [System.NonSerialized]
    public Vector3 LevelTilePos;

    [SerializeField]
    public GameObject MapTilePrefab;

    [SerializeField]
    public GameObject LevelTilePrefab;

    [System.NonSerialized]
    public GameObject[,] MapTileArray = new GameObject[30, 20];
    [System.NonSerialized]
    public GameObject[,] LevelTileArray = new GameObject[30, 20];

    [SerializeField]
    public GameObject CreateGridRef;


    public void Update()
    {
        if (EnableRunning & (CreationDone == false))
        {
            for (float x = 0; x < MaxX; x++)
            {
                for (float y = 0; y < MaxY; y++)
                {
                    //This is for creating the map grid
                    CurrentX = x / 10;
                    CurrentY = y / 10;
                    CurrentPos.x = transform.position.x + CurrentX;
                    CurrentPos.y = transform.position.y + CurrentY;
                    CurrentPos.z = transform.position.z;
                    //Debug.Log(CurrentX + " " + CurrentY + " " + (x / 10) + " " + CurrentPos);

                    //I'VE DISABLED THESE BECAUSE THIS IS WHAT CREATES IT, I NEED TO FINISH SETTING IT UP BEFORE CREATING THEM SO THEY CAN HAVE EVERYTHING THEY NEED
                    //var NewMapTile = Instantiate(MapTilePrefab, (CurrentPos), Quaternion.identity);   //THIS IS WHAT I WAS USING, IT CREATES A CLONE RATHER THAN AN INSTANCE OF THE PREFAB, FIRST
                    GameObject NewMapTile = PrefabUtility.InstantiatePrefab(MapTilePrefab) as GameObject;
                    NewMapTile.transform.position = CurrentPos;
                    NewMapTile.transform.GetComponent<MapTileStats>().CoordX = x + 1f;
                    NewMapTile.transform.GetComponent<MapTileStats>().CoordZ = y + 1f;
                    MapTileArray[(int)x + 1, (int)y + 1] = NewMapTile.gameObject;
                    NewMapTile.transform.GetComponent<MapTileStats>().CreateGridRef = CreateGridRef;

                    //This is for creating the level grid
                    LevelTilePos = new Vector3 (0f, 0f, 0f);
                    LevelTilePos.x += x * 4;
                    LevelTilePos.z += y * 4;
                    //var NewLevelTile = Instantiate(LevelTilePrefab, LevelTilePos, Quaternion.identity);    //THIS IS WHAT I WAS USING, IT CREATES A CLONE RATHER THAN AN INSTANCE OF THE PREFAB, SECOND
                    GameObject NewLevelTile = PrefabUtility.InstantiatePrefab(LevelTilePrefab) as GameObject;
                    NewLevelTile.transform.position = LevelTilePos;
                    NewLevelTile.transform.GetComponent<LevelTileStats>().CoordX = x + 1f;
                    NewLevelTile.transform.GetComponent<LevelTileStats>().CoordZ = y + 1f;
                    LevelTileArray[(int)x + 1, (int)y + 1] = NewLevelTile.gameObject;
                    NewLevelTile.transform.GetComponent<LevelTileStats>().CreateGridRef = CreateGridRef;

                    NewLevelTile.GetComponent<LevelTileStats>().MapRef = NewMapTile;
                    NewMapTile.GetComponent<MapTileStats>().LevelRef = NewLevelTile;
                    NewMapTile.GetComponent<TileSpawner>().MapRef = NewMapTile;
                    NewMapTile.GetComponent<TileSpawner>().LevelRef = NewLevelTile;
                    NewMapTile.GetComponent<TileSpawner>().CoordX = x + 1;
                    NewMapTile.GetComponent<TileSpawner>().CoordY = y + 1;
                }
            }
            CreationDone = true;
        }
    }


    public void CreateGridFunction()
    {

    }
}
