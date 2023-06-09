using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private static bool finalTransitionComplete = false;

    // Update is called once per frame
    void Update()
    {
        // If space is pressed, load next level (if there is one)
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

        if (levelIndex == SceneManager.sceneCountInBuildSettings - 1) {
            finalTransitionComplete = true;
        }
    }

    public static bool FinalTransitionComplete()
    {
        return finalTransitionComplete;
    }
}
