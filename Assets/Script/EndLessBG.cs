using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EndLessBG : MonoBehaviour
{
    public GameObject[] testMap;
    public Transform helicopter;   // Helicopter moves forward
    public GameObject[] backgrounds; // Background prefabs (Forest, Village)
    public int initialSpawnCount = 3; // How many maps to start with

    private Queue<GameObject> activeBackgrounds = new Queue<GameObject>();

    GameObject firstBackground;

    void Start()
    {
        firstBackground = SpawnNewBackground(Vector3.zero);

        // Spawn additional backgrounds connected to the first one
        for (int i = 1; i < initialSpawnCount; i++)
        {
            firstBackground = SpawnNewBackground(firstBackground.GetComponent<MapPiece>().endMarker.position);
        }

        for (int i = 0; i < testMap.Length; i++)
        {
            testMap[i].gameObject.SetActive(false);
        }
    }


    void Update()
    {
        // Check if the helicopter has passed the first background's endMarker
        if (helicopter.position.z > activeBackgrounds.Peek().GetComponent<MapPiece>().endMarker.position.z + 150)
        {
            firstBackground = SpawnNewBackground(firstBackground.GetComponent<MapPiece>().endMarker.position);

            GameObject db = activeBackgrounds.Dequeue();
            Destroy(db);
        }
    }

    Vector3 CalculateSpawnPosition(Vector3 lastPos, MapPiece nextPos)
    {
        return lastPos + (nextPos.endMarker.position - nextPos.startMarker.position) / 2;
    }

    GameObject SpawnNewBackground(Vector3 position)
    {
        GameObject bgPrefab = backgrounds[Random.Range(0, backgrounds.Length)];
        GameObject newBG = Instantiate(bgPrefab, CalculateSpawnPosition(position, bgPrefab.GetComponent<MapPiece>()), Quaternion.identity);
        activeBackgrounds.Enqueue(newBG);
        return newBG;
    }
}
