using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShotNote : MonoBehaviour {

    public GameObject spawner;
    public GameObject spawnObj;
    public bool randomColor = false;
    

    public float[] colorCode = { 0, 1, 0, 1, 0, 1, 0, 1 };

    public float force = 10;
    public float interval = 0.5f;
    public bool toShoot = true;
    public float deathTime = 5f;

    public GameObject forceDisp;
    public GameObject intervalDisp;
    public GameObject toShootDisp;
    public GameObject deathTimeDisp;

    void Start()
    {
        StartCoroutine(delay());
    }
    void Update()
    {
        float bpm = 60 / interval;
        forceDisp.GetComponent<Text>().text = "Force: \n"+force.ToString("0");
        intervalDisp.GetComponent<Text>().text = "BPM: \n"+bpm.ToString("0");
        toShootDisp.GetComponent<Text>().text = "Shoot: "+toShoot.ToString();
       // deathTimeDisp.GetComponent<Text>().text = "Death Time: \n"+deathTime.ToString();
    }

    void shot()
    {
            GameObject theOBJ;
            theOBJ = Instantiate(spawnObj, spawner.transform.position, spawner.transform.rotation) as GameObject;

        // Add velocity to the bullet
        theOBJ.GetComponent<Rigidbody>().velocity = theOBJ.transform.forward * force;

        theOBJ.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;

        if (randomColor == true) {
            Color newColor = Random.ColorHSV(colorCode[0], colorCode[1], colorCode[2], colorCode[3], colorCode[4], colorCode[5], colorCode[6], colorCode[7]);
            theOBJ.GetComponent<Renderer>().material.color = newColor;
        }

        Destroy(theOBJ, deathTime);
    }


   private IEnumerator delay()
    {
        while (1==1)
        {
            yield return new WaitForSeconds(interval);
            if (toShoot)
            {
                shot();
            }
        }
    }

}

