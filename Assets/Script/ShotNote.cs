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

    public float force;

    public float interval;

    public bool toShoot;

    void Start()
    {
        StartCoroutine(delay());
    }
    private string colorCodeString;
    public GameObject colorCodeStringDisp;

    public void MyFunction(string MyCount)
    {
        if (MyCount == "CANCELED")
        {
            print("Canceled");
            colorCodeString = "";
            MyCount = "";
        }

        colorCodeString += MyCount;
        print(colorCodeString);
    }

    void Update()
    {
        Text text = colorCodeStringDisp.GetComponent<Text>();
        text.text = colorCodeString;
    }

    void shot()
    {
            GameObject theOBJ;
            theOBJ = Instantiate(spawnObj, spawner.transform.position, spawner.transform.rotation) as GameObject;

        // Add velocity to the bullet
        theOBJ.GetComponent<Rigidbody>().velocity = theOBJ.transform.forward * force;

        Color newColor = Random.ColorHSV(colorCode[0], colorCode[1], colorCode[2], colorCode[3], colorCode[4], colorCode[5], colorCode[6], colorCode[7]);
        colorCodeString = newColor.ToString();
        colorCodeString = colorCodeString.Substring(4);
        Debug.Log(colorCodeString);
        if (randomColor == true) {
            theOBJ.GetComponent<Renderer>().material.color = newColor;
            this.GetComponent<Renderer>().material.color = newColor;
        }

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

