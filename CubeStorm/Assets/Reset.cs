using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    [SerializeField]
    private string highScore;

    public bool dead { get; set; }

    public GameObject o1;
    public GameObject o2;
    public Text o3;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        if (PlayerPrefs.HasKey("score"))
        {
            highScore = PlayerPrefs.GetString("score");
        }
        else
        {
            highScore = "0.00";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            string s = gameObject.GetComponent<Score>().score;

            float time = float.Parse(s);

            float minutes = time / 60f;
            float seconds = time % 60f;

            float time2 = float.Parse(highScore);

            float minutes2 = time2 / 60f;
            float seconds2 = time2 % 60f;

            if (minutes > minutes2)
            {
                highScore = s;
            }else if (minutes == minutes2 && seconds > seconds2)
            {
                highScore = s;
            }

            o3.text = "Best Time: " + highScore;
            o1.SetActive(true);
            o2.SetActive(true);
            o3.gameObject.SetActive(true);
            PlayerPrefs.SetString("score", highScore);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Move the cube if the screen has the finger moving.
                if (touch.phase == TouchPhase.Began)
                {
                    dead = false;

                    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                }
            }
        }
    }
}
