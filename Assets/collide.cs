using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour
{
    public GameObject particle;
    bool trig = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            other.gameObject.GetComponent<player>().dead = true;

           
        }
        if (other.gameObject.tag == "Cube")
        {
            Debug.Log("Hit Cube");
            //Destroy(other.gameObject);
        }
    }
}
