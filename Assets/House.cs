using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class House : MonoBehaviour
{
    public Db db;
    public GameObject waterEF;

    public int patience;

    private void Start()
    {
        patience = Random.Range(4, 8);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Check if the object is water
        {
            StartCoroutine(DestroyWater()); // Destroy the fire object
        }
    }

    IEnumerator DestroyWater()
    {
        int score = Random.Range(1, 3);
        patience -= score;

        if (patience < 0)
            db.AddScore(-score);
        else
            db.AddScore(score);


        // Instantiate the water effect at the fire’s position
        GameObject effect = Instantiate(waterEF, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2f); // Wait 2 seconds before destroying effect

        Destroy(effect); // Destroy the water effect
    }
}
