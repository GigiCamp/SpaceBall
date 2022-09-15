using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animation>().Play();
        unityEvent.Invoke();
        GetComponent<BoxCollider>().isTrigger = false;
    }
}
