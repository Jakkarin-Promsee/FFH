using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 10f;  // Constant forward speed
    public float sideSpeed = 5f;      // Left/right movement speed
    public GameObject waterEffect;    // Water effect prefab
    public Transform dropPoint;       // Where water drops from
    public float dropCD = 0.1f;
    public AudioSource waterSFX;      // Sound effect for dropping water

    float currentDropT = 0;

    private void Update()
    {

        // Move forward automatically
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Get left/right input (A/D or Left/Right arrows)
        // float horizontalInput = Input.GetAxis("Horizontal");

        // Drop water when pressing Enter
        if (Input.GetKey(KeyCode.Return) && currentDropT < Time.time)
        {
            currentDropT = Time.time + dropCD;
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
