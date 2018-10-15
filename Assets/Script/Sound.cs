using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip drumSound;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        float vol  = collision.relativeVelocity.magnitude * 0.2f;
        Debug.Log(vol);
        audioSource.PlayOneShot(drumSound, vol);
    }
}
