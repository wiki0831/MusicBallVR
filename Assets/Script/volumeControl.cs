using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeControl : MonoBehaviour {

    public GameObject sound;
    public float mod;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            sound.GetComponent<Sound>().maxVolume = sound.GetComponent<Sound>().maxVolume + mod;
    }
}
