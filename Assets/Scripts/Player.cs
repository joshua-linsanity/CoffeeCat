using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private Vector3 direction;
    public float gravity = -9.81f;
    public float jumpStrength = 5f;
    public int bonusMultiplier = 3;
    public int coffeeLossMultiplier = -10;

    // Awake is called before Start
    private void Awake() 
    {
        // Searches for the SpriteRenderer component on the GameObject (Player)
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    private void Start() 
    {
        // Invoke calls another function, Repeating calls it again and again
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

    }

    // OnEnable is called when the GameObject becomes active
    private void OnEnable() 
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // If space key pressed or mouse left button clicked, move up
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * jumpStrength;
        }

        // Check for touch input
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            // If touch just began, move up
            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * jumpStrength;
            }
        }

        // Apply gravity
        direction.y += gravity * Time.deltaTime;
        // Multiply by deltaTime to make movement frame rate independent
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (!(spriteIndex < sprites.Length)) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // If player collides with obstacle, game over
        if (other.CompareTag("Obstacles")) {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.CompareTag("Scoring")) {
            FindObjectOfType<GameManager>().ChangeScore(1);
        } else if (other.CompareTag("Bonus")) {
            FindObjectOfType<GameManager>().ChangeScore(bonusMultiplier);
        } else if (other.CompareTag("Coffee")) {
            FindObjectOfType<GameManager>().ChangeScore(coffeeLossMultiplier);
        }
    }
}
