using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XCanvas : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (LevelLoader.FinalTransitionComplete()) {
            gameObject.SetActive(false);
        }
    }
}
