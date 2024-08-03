using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreExplosion : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            StartCoroutine(Test());
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}