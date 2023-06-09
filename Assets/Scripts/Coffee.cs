using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public float verticalSpeed;
    public float amplitude;
    private Vector3 startPosition;
    private float speed, leftEdge;
    private void Start()
    {
        // Store starting position of cake
        startPosition = transform.position;

        // Get speed, leftEdge, and offset from Obstacles script
        Obstacles obstacles = FindObjectOfType<Obstacles>();
        float[] values = obstacles.GetValues();
        speed = values[0];
        leftEdge = values[1];
    }

    private void Update()
    {
        // Move the cake up and down
        float y = Mathf.Sin(Time.time * verticalSpeed) * amplitude;
        transform.position += new Vector3(0, y, 0) * Time.deltaTime;

        // Move the cake to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy the cake if it goes off screen
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            // Deactivate this cake
            this.gameObject.SetActive(false);
        }    
    }
}
