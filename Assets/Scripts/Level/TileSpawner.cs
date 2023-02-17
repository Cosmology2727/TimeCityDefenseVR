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
            var NewLevelObj = Instantiate(ToSpawnObj, LevelRef.transform.position, Quaternion.identity);
        }
    }
}
