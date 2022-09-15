using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 800;

    List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();

    void FixedUpdate()
    {
        magnetForce = 800;
        if(gameObject.transform.rotation.eulerAngles.y > 160 && gameObject.transform.rotation.eulerAngles.y < 180)
        {
            magnetForce = 100;
        }
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].velocity = (transform.position - (caughtRigidbodies[i].transform.position + caughtRigidbodies[i].centerOfMass)) * magnetForce * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();

            if (!caughtRigidbodies.Contains(r))
            {
                //Add Rigidbody
                caughtRigidbodies.Add(r);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();

            if (caughtRigidbodies.Contains(r))
            {
                //Remove Rigidbody
                caughtRigidbodies.Remove(r);
            }
        }
    }
}
