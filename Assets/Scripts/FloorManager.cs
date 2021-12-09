using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] floorPrefabs;
    public void SpawnFloor()
    {
        int r = Random.Range(0, floorPrefabs.Length);
        Instantiate(floorPrefabs[r], transform);
    }
}
