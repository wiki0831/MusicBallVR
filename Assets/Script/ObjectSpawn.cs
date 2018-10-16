using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {


    public GameObject objRespawn;
    public float interval = 1.0f;
    public bool randomColor= false;

    public float hueMin = 0f;
    public float hueMax = 1f;
    public float saturationMin = 0f;
    public float saturationMax = 1f;
    public float valueMin = 0f;
    public float valueMax = 1f;
    public float alphaMin = 0f;
    public float alphaMax = 1f;

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
        Color newColor = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, alphaMin, alphaMax);
        if (randomColor == true)copy.GetComponent<Renderer>().material.color = newColor;

        clonedTarget = copy;
    }
}
