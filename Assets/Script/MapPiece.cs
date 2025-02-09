using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    public Transform startMarker;   // Start position for connection
    public Transform endMarker;     // End position for connection

    public GameObject[] fireSpots;  // Positions where fire should be placed
    public GameObject[] bombSpots;  // Positions where bombs should be placed

    public GameObject firePrefab;   // Prefab for fire hazard
    public GameObject bombPrefab;   // Prefab for bomb hazard

    void Start()
    {
        SpawnHazards();
    }

    void SpawnHazards()
    {
        // Randomly place fires
        foreach (GameObject spot in fireSpots)
        {
            if (Random.value > 0.5f) // 50% chance to spawn fire
            {
                Instantiate(firePrefab, spot.transform.position, Quaternion.identity, transform);
            }
        }

        // Randomly place bombs
        foreach (GameObject spot in bombSpots)
        {
            if (Random.value > 0.5f) // 50% chance to spawn bomb
            {
                Instantiate(bombPrefab, spot.transform.position, Quaternion.identity, transform);
            }
        }
    }
}
