using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Db db;
    public GameObject waterEF;

    private GameObject playerRef;

    void Start()
    {
        // Find the GameObject with the tag "PlayerRef"
        playerRef = GameObject.FindGameObjectWithTag("PlayerRef");

        if (playerRef != null)
        {
            Debug.Log("Found PlayerRef: " + playerRef.name);
        }
        else
        {
            Debug.LogError("No GameObject with tag 'PlayerRef' found!");
        }

        if (playerRef.GetComponent<Transform>().position.z + 50 > transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Check if the object is water
        {
            StartCoroutine(DestroyFire()); // Destroy the fire object
        }
    }

    private void Update()
    {
        if (Time.time > 4)
            if (playerRef.GetComponent<Transform>().position.z > transform.position.z + 50)
            {
                db.AddScore(-2);
                Destroy(gameObject);
            }
    }

    IEnumerator DestroyFire()
    {
        db.AddScore(Random.Range(1, 3));

        // Instantiate the water effect at the fire’s position
        GameObject effect = Instantiate(waterEF, transform.position, Quaternion.identity);

        Destroy(gameObject); // Destroy the fire object

        yield return new WaitForSeconds(2f); // Wait 2 seconds before destroying effect

        Destroy(effect); // Destroy the water effect
    }
}
