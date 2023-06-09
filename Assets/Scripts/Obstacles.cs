using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed;
    private float leftEdge;
    private float offset = 1f;

    // Calculate left edge of screen
    private void Start() 
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - offset;
    }

    private void Update() 
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

    // Get values for use in other programs
    public float[] GetValues() 
    {
        float[] values = {speed, leftEdge};
        return values;
    }
}
