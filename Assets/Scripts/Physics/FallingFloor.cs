using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    private Rigidbody fallingFloor;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        fallingFloor = gameObject.transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            if (timer > 0.5) { 
                fallingFloor.isKinematic = false; 
                fallingFloor.useGravity = true; 
            }
        }
    }

}
