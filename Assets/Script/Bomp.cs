using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomp : MonoBehaviour
{
    public Db db;
    public GameObject bombEF;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Check if the object is water
        {
            StartCoroutine(BombExplosion()); // Destroy the fire object
        }
    }

    IEnumerator BombExplosion()
    {
        // Instantiate the water effect at the fire’s position
        GameObject effect = Instantiate(bombEF, transform.position, Quaternion.identity);

        // Destroy(gameObject); // Destroy the fire object

        yield return new WaitForSeconds(1f); // Wait 2 seconds before destroying effect

        Destroy(effect); // Destroy the water effect

        db.SetWin(-1);

        SceneManager.LoadScene("wining");
    }
}
