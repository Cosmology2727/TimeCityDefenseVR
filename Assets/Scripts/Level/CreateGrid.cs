using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateGrid : MonoBehaviour
{
    [SerializeField]
    public bool EnableRunning = false;
    [SerializeField]
    public bool CreationDone = false;

    [System.NonSerialized]
    public int MaxX = 30;
    [System.NonSerialized]
    public int MaxY = 25;
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
                    var NewMapTile = Instantiate(MapTilePrefab, (CurrentPos), Quaternion.identity);
                    NewMapTile.transform.GetComponent<MapTileStats>().CoordX = x + 1f;
                    NewMapTile.transform.GetComponent<MapTileStats>().CoordZ = y + 1f;

                    //This is for creating the level grid
                    LevelTilePos = new Vector3 (0f, 0f, 0f);
                    LevelTilePos.x += x * 2;
                    LevelTilePos.z += y * 2;
                    var NewLevelTile = Instantiate(LevelTilePrefab, LevelTilePos, Quaternion.identity);
                    NewLevelTile.transform.GetComponent<LevelTileStats>().CoordX = x + 1f;
                    NewLevelTile.transform.GetComponent<LevelTileStats>().CoordZ = y + 1f;


                    NewLevelTile.GetComponent<LevelTileStats>().MapRef = NewMapTile;
                    NewMapTile.GetComponent<MapTileStats>().LevelRef = NewLevelTile;
                    NewMapTile.GetComponent<TileSpawner>().MapRef = NewMapTile;
                    NewMapTile.GetComponent<TileSpawner>().LevelRef = NewLevelTile;
                    NewMapTile.GetComponent<TileSpawner>().CoordX = x;
                    NewMapTile.GetComponent<TileSpawner>().CoordY = y;
                }
            }
            CreationDone = true;
        }
    }


    public void CreateGridFunction()
    {

    }
}
