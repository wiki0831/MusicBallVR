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
        volumeDisp.GetComponent<Text>().text = "Voulme: \n" + maxVolume.ToString(("0.##"));
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    { 
        float velocity = collision.relativeVelocity.magnitude;
        PlaySound(velocity);
        volumeDisp.GetComponent<Text>().text = "Voulme: \n" + maxVolume.ToString(("0.##"));
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
