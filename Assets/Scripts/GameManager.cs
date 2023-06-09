using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public AudioSource backgroundMusic;
    public AudioSource gameOverMusic;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private void Awake() 
    {
        // Set frame rate to 60 fps
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);

        Pause();
    }

    public void Play() 
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Reset all obstacles, bonus cakes, and coffee
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();
        for (int i = 0; i < obstacles.Length; i++) {
            Destroy(obstacles[i].gameObject);
        }
        Cake[] cakes = FindObjectsOfType<Cake>();
        for (int i = 0; i < cakes.Length; i++) {
            Destroy(cakes[i].gameObject);
        }
        Coffee[] coffees = FindObjectsOfType<Coffee>();
        for (int i = 0; i < coffees.Length; i++) {
            Destroy(coffees[i].gameObject);
        }
        
        Time.timeScale = 1f;
        player.enabled = true;

        // Reset music to beginning
        backgroundMusic.time = 0f;
        backgroundMusic.Play();
    }

    public void Pause() 
    {
        // Freeze time
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        backgroundMusic.Stop();
        gameOverMusic.Play();
        Pause();
    }

    public void ChangeScore(int amount) 
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
