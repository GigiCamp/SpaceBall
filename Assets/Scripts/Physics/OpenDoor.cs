using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public void PlayAnimation()
    {
        GetComponent<Animation>().Play();
    }
}
