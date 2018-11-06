using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interval : MonoBehaviour {

    public GameObject spawner;
    public float mod;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            spawner.GetComponent<ShotNote>().interval = spawner.GetComponent<ShotNote>().interval + mod;
    }
}
