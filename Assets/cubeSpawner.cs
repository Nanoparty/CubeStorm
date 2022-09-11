using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSpawner : MonoBehaviour
{
    private float time;

    float num = 3;
    float speed = 1;

    public GameObject cube;
    public GameObject target;

    float spawnRate = .1f;
    int spawnCount = 40;
    
    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        start = (target.transform.position - transform.position) * speed;
        time += Time.deltaTime;
        //Debug.Log("Time" + time);
        if (time >= spawnRate)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 randomVec = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-25f, 2f));
                GameObject obj = Instantiate(cube, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)) + transform.position, Quaternion.identity);
                Vector3 vel = (target.transform.position - transform.position) * speed + randomVec;
                //vel = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1))*speed;
                obj.GetComponent<Rigidbody>().velocity = vel;
            }
            time = 0;
        }
    }
}
