using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour

{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(0, 3, -4);
        gameObject.transform.position = target.transform.position + vector;
        transform.LookAt(target.transform);
    }
}
