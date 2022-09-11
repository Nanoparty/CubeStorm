using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSceneSwitch : MonoBehaviour
{

    AudioSource audio;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Ended)
            {
                audio.Play();
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
        
    }
}
