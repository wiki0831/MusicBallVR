using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotNote : MonoBehaviour {

    public GameObject spawner;
    public GameObject spawnObj;
    public bool randomColor = false;
    public float hueMin = 0f;
    public float hueMax = 1f;
    public float saturationMin = 0f;
    public float saturationMax = 1f;
    public float valueMin = 0f;
    public float valueMax = 1f;
    public float alphaMin = 0f;
    public float alphaMax = 1f;

    public float force;

    public float interval;

    public bool toShoot;

    void Start()
    {
        StartCoroutine(delay());
    }

    void shot()
    {

            GameObject theOBJ;
            theOBJ = Instantiate(spawnObj, spawner.transform.position, spawner.transform.rotation) as GameObject;

        // Add velocity to the bullet
        theOBJ.GetComponent<Rigidbody>().velocity = theOBJ.transform.forward * force;

        Color newColor = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, alphaMin, alphaMax);
        if (randomColor == true) theOBJ.GetComponent<Renderer>().material.color = newColor;

        Destroy(theOBJ, 3.0f);
        }


    IEnumerator delay()
    {
        while(toShoot == true) {
            yield return new WaitForSeconds(interval);
            shot();
        }
    }

}

