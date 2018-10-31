using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public GameObject effectTarget;
    public float delay = 1.0f;

    private Vector3 originPosition;
    private Quaternion originRotation;

    private GameObject clonedTarget;

    public bool randomColor = false;
    public float[] colorCode = { 0, 1, 0, 1, 0, 1, 0, 1 };

    private void Start()
    {
        clonedTarget = effectTarget;
        originPosition = effectTarget.transform.localPosition;
        originRotation = effectTarget.transform.localRotation;
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
        yield return new WaitForSeconds(delay);

        var copy = Instantiate(effectTarget);
        copy.transform.SetParent(effectTarget.transform.parent);
        copy.transform.localPosition = originPosition;
        copy.transform.localRotation = originRotation;
        copy.name = effectTarget.name;

        if (randomColor == true)
        {
            Color newColor = Random.ColorHSV(colorCode[0], colorCode[1], colorCode[2], colorCode[3], colorCode[4], colorCode[5], colorCode[6], colorCode[7]);
            copy.GetComponent<Renderer>().material.color = newColor;
        }

        clonedTarget = copy;
    }
}
