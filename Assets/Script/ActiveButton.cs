using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //buttonOriginPosition = buttonObject.localPosition;
    }
	
	// Update is called once per frame
	void Update () { 
    }

    public Transform buttonObject;
    public Vector3 buttonDownDisplacement;
    //private Vector3 buttonOriginPosition;
    public GameObject toControl;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.gameObject.name);

        if (other.gameObject.tag == "Player")
        {
            //buttonObject.transform.localPosition = buttonOriginPosition + buttonDownDisplacement;

            if (toControl.GetComponent<ShotNote>().toShoot == false)
            {
                toControl.GetComponent<ShotNote>().toShoot = true;
            }
            else
            {
                toControl.GetComponent<ShotNote>().toShoot = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //buttonObject.localPosition = buttonOriginPosition;
    }
}
