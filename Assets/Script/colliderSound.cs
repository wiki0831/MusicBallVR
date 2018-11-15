using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderSound : MonoBehaviour {

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Sound") {
            audioSource.Play();
        }
    }
}
