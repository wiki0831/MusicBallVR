using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour {

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();
    }
}
