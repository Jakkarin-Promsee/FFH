using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterFall : MonoBehaviour
{
    public float fallingSpeed = 10f;  // Constant forward speed

    public Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }
    private void Update()
    {
        transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);


        if (transform.position.y < 0.0f)
            Destroy(gameObject);

    }
}
