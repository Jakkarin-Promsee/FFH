using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 10f;  // Constant forward speed
    public float sideSpeed = 5f;      // Left/right movement speed
    public GameObject waterEffect;    // Water effect prefab
    public Transform dropPoint;       // Where water drops from
    public AudioSource waterSFX;      // Sound effect for dropping water

    private void Update()
    {
        // Move forward automatically
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Get left/right input (A/D or Left/Right arrows)
        // float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalInput = 0;
        transform.Translate(Vector3.right * horizontalInput * sideSpeed * Time.deltaTime);

        // Drop water when pressing Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DropWater();
        }
    }

    void DropWater()
    {
        // Instantiate water effect
        Instantiate(waterEffect, dropPoint.position, Quaternion.identity);

        // Play water sound effect
        if (waterSFX != null)
        {
            waterSFX.Play();
        }
    }
}
