using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public float movementSpeed = 2f;    
    public float movementAmount = 5f;
    Vector3 startPos;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * Time.timeScale * movementSpeed;
        transform.position = startPos + Vector3.up * Mathf.Sin(time) * movementAmount;
    }
}
