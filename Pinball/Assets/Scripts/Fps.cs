using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fps : MonoBehaviour
{
    int fps = 0;
    float fpsTimer;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        fps++;
        fpsTimer += Time.deltaTime;

        if (fpsTimer > 1)
        {
            text.text = "Fps: " + fps;
            fpsTimer = 0;
            fps = 0;
        }
    }
}
