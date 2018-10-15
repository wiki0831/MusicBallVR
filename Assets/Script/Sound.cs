using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip sound;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        float velocity = collision.relativeVelocity.magnitude;
        PlaySound(velocity);
    }

    void PlaySound(float velocity)
    {
   
        if (velocity > 5)
        {
            velocity = 5;
        }
        float vol = velocity * 0.2f;
        Debug.Log(vol);
        audioSource.PlayOneShot(sound, vol);
    }
}
