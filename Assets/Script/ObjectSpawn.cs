using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {


    public GameObject objRespawn;
    public float interval = 1.0f;
    public bool randomColor= false;

    public float[] colorCode = { 0, 1, 0, 1, 0, 1, 0, 1 };

    private Vector3 objPosition;
    private GameObject clonedTarget;

    // Use this for initialization
    void Start () {
        clonedTarget = objRespawn;
        objPosition = objRespawn.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == clonedTarget)
        {
            StopAllCoroutines();
            StartCoroutine(CopyTarget());

           
        }
    }

    private IEnumerator CopyTarget()
    {
        yield return new WaitForSeconds(interval);

        var copy = Instantiate(objRespawn);
       
        copy.transform.localPosition = objPosition;

        copy.name = objRespawn.name;
        Color newColor = Random.ColorHSV(colorCode[0], colorCode[1], colorCode[2], colorCode[3], colorCode[4], colorCode[5], colorCode[6], colorCode[7]);
        if (randomColor == true)copy.GetComponent<Renderer>().material.color = newColor;

        clonedTarget = copy;
    }
}
