using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public GameObject spawner;
    public float mod;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            spawner.GetComponent<ShotNote>().force = spawner.GetComponent<ShotNote>().force + mod;
    }
}
