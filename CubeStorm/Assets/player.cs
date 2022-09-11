using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class player : MonoBehaviour
{
    CharacterController characterController;

    AudioSource audio;
    bool audioPlayed = false;

    public float speed = 100;
    //public float jumpSpeed = 8.0f;
    public float gravity = 0.0f;

    public Joystick joystick;

    public GameObject ScoreKeeper;

    private Vector3 moveDirection = Vector3.zero;

    public bool dead { get; set; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        dead = false;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        // We are grounded, so recalculate
        // move direction directly from axes

        moveDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);
        moveDirection *= speed;

           
        if (dead)
        {
            if (!audioPlayed)
            {
                audio.Play();
                audioPlayed = true;
            }
            ScoreKeeper.GetComponent<Reset>().dead = true;
            ScoreKeeper.GetComponent<Score>().dead = true;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        //moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}