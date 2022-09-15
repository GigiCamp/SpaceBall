using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    [HideInInspector]
    public bool collided = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleCube"))
        {
            collided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PuzzleCube"))
        {
            collided = false;
        }
    }
}
