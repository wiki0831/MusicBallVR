using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onContactAttach : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sound") {
            Debug.Log("ATTACHED");
            transform.SetParent(collision.transform);
            GetComponent<Rigidbody>().isKinematic = true;

            GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
        }
    }
}
