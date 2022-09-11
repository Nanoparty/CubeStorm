using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public string score { get; set; }
    public float time;

    public Text text;
    public bool dead { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        score = time.ToString();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            time += Time.deltaTime;
        }
        score = time.ToString("0.00");
        text.text = score;
    }
}
