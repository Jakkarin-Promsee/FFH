using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject waterEF;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Check if the object is water
        {
            StartCoroutine(DestroyFire()); // Destroy the fire object
        }
    }

    IEnumerator DestroyFire()
    {
        // Instantiate the water effect at the fire’s position
        GameObject effect = Instantiate(waterEF, transform.position, Quaternion.identity);

        Destroy(gameObject); // Destroy the fire object

        yield return new WaitForSeconds(2f); // Wait 2 seconds before destroying effect

        Destroy(effect); // Destroy the water effect
    }
}
