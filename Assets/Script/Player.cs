using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int winStarRequire = 5;
    public Sprite nonStar;
    public Sprite fullStar;
    public Image[] starPrefab;
    public String winingScence = "Wining";
    public Db db;
    public TextMeshPro text;
    public TextMeshPro textBg;
    public float forwardSpeed = 10f;  // Constant forward speed
    public float sideSpeed = 5f;      // Left/right movement speed
    public GameObject waterEffect;    // Water effect prefab
    public Transform dropPoint;       // Where water drops from
    public float dropCD = 0.1f;
    public AudioSource waterSFX;      // Sound effect for dropping water
    private bool canPlay = true;

    float currentDropT = 0;

    private void Start()
    {
        db.Reset();
    }

    IEnumerator EnablePlayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canPlay = true; // Enable playing again after delay
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && canPlay)
        {
            if (!waterSFX.isPlaying)
            {
                waterSFX.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            waterSFX.Stop();
            canPlay = false; // Prevent immediate replay
            StartCoroutine(EnablePlayAfterDelay(0.2f)); // Wait 0.2s before allowing play again
        }

        if (db.star > winStarRequire)
        {
            db.SetWin(1);
            SceneManager.LoadScene(winingScence);
        }

        if (db.star <= 0 && db.score < 0)
        {
            db.SetWin(-1);
            SceneManager.LoadScene("wining");
        }

        for (int i = 0; i < starPrefab.Length; i++)
        {
            if (i < db.star)
                starPrefab[i].sprite = fullStar;
            else
                starPrefab[i].sprite = nonStar;
        }

        db.AddTime(Time.deltaTime);

        string txt = "Score: " + db.score + "/10";
        text.text = txt;
        textBg.text = txt;

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

    }
}
