using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    // Get reference to Text Mesh Pro button
    private Button button;
    public AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        FindObjectOfType<GameManager>().Play();
        button.gameObject.SetActive(false);
    }

    private void OnDisable() {
        audioSource.Play();
    }
}
