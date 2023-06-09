using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Get reference to the obstacle prefab
    public GameObject obstaclePrefab;
    // How often should obstacles be spawned? 
    public float spawnRate;

    // Get reference to bonus prefab
    public GameObject bonusPrefab;
    public float bonusProbability = 0.15f;

    // Get reference to coffee prefab
    public GameObject coffeePrefab;
    public float coffeeProbability = 0.1f;

    // Randomize width and height parameters of spawned objects
    public float minHeight;
    public float maxHeight;
    private float minWidth = 3f;
    private float maxWidth = 6f;
    public float verticalOffset = 1.5f;

    // OnEnable because spawn needs to end when player loses/wins
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Create new obstacle at spawner position with no rotation
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        obstacle.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        Vector3 offset = new Vector3(0, verticalOffset, 0);

        // Create new bonus cake at spawner position with no rotation
        if (Create(bonusProbability)) {
            GameObject bonus = Instantiate(bonusPrefab, obstacle.transform.position + offset, Quaternion.identity);
            bonus.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            bonus.transform.position += Vector3.right * Random.Range(minWidth, maxWidth);
        } else if (Create(coffeeProbability)) {
            // Create new bonus coffee at spawner position with no rotation (if no bonus cake)
            GameObject coffee = Instantiate(coffeePrefab, obstacle.transform.position + offset, Quaternion.identity);
            coffee.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
            coffee.transform.position += Vector3.right * Random.Range(minWidth, maxWidth);
        }
    }

    private bool Create(float cutoffProbability) 
    {
        // Randomly decide if this bonus cake will appear
        float p = Random.Range(0f, 1f);
        if (p < cutoffProbability) {
            return true;
        }
        return false;
    }
}
