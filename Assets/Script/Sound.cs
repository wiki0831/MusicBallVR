using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

    AudioSource audioSource;
    public GameObject volumeDisp;

    public float maxVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //volumeDisp.GetComponent<Text>().text = "Voulme: \n" + audioSource.volume.ToString();
        volumeDisp.GetComponent<Text>().text = "Voulme: \n" + maxVolume.ToString();
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

        if (vol > maxVolume)
        {
            audioSource.volume = maxVolume;
        }
        else
        {
            audioSource.volume = vol;
        }

        audioSource.Play();

    }
}
