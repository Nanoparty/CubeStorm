using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeshot : MonoBehaviour
{
    Vector3 rotation;
    float x, y, z;
    float speed = 2;

    public float min = .1f;
    public float max = .3f;

    Rigidbody rb;

    //GameObject target;

    public float maxVel = .5f;

    Vector3 vel;
    // Start is called before the first frame update


    void Start()
    {

        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        var cubeRenderer = GetComponent<Renderer>();

        //cubeRenderer.material.color = newColor;

        rb = GetComponent<Rigidbody>();

        //target = GameObject.FindGameObjectWithTag("Player");

        //vel = target.transform.position - transform.position;

        //Debug.Log("Vel" + vel);

        x = Random.Range(min, max);
        y = Random.Range(min, max);
        z = Random.Range(min, max);

        //rb.velocity = vel * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z, Space.Self);

        if (rb.velocity.magnitude > 6)
        {
            rb.velocity = rb.velocity * 0.75f;
        }

        

        
    }
}
