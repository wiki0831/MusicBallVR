using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


   public GameObject fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn" || other.gameObject.tag == "Sound")
        {
            other.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            var copy = Instantiate(fire);
            copy.transform.SetParent(other.transform);
            copy.transform.localPosition = new Vector3(0,0,0);
            //copy.transform.localRotation = other.transform.localRotation;
            copy.name = fire.name;
            Destroy(other.gameObject, 2f);
        }
    }
}
