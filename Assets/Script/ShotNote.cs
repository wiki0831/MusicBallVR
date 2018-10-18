using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotNote : MonoBehaviour {

    public GameObject spawner;

    public GameObject spawnObj;

    public float force;

    public bool toShoot;

    void Start()
    {
        StartCoroutine(delay());
    }

    void shot()
    {

            GameObject theOBJ;
            theOBJ = Instantiate(spawnObj, spawner.transform.position, spawner.transform.rotation) as GameObject;

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = theOBJ.GetComponent<Rigidbody>();


            Temporary_RigidBody.AddForce(transform.forward * force);


            Destroy(theOBJ, 3.0f);
        }


    IEnumerator delay()
    {
        while(toShoot == true) {
            yield return new WaitForSeconds(0.3f);
            shot();
        }
    }

}

