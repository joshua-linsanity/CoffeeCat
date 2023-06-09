using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSceneButton : MonoBehaviour
{
    // Get reference to Text Mesh Pro button
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
        gameObject.GetComponent<AudioSource>().Play();
    }
}
