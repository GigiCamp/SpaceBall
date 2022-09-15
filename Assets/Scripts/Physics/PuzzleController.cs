using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject puzzlePlatform1;
    public GameObject puzzlePlatform2;
    public GameObject puzzlePlatform3;

    public GameObject puzzleCube1;
    public GameObject puzzleCube2;
    public GameObject puzzleCube3;

    private bool puzzlePlatform1Check;
    private bool puzzlePlatform2Check;
    private bool puzzlePlatform3Check;

    private bool allCheck;
    private float gateSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        puzzlePlatform1Check = puzzlePlatform1.GetComponent<ColliderDetector>().collided;
        puzzlePlatform2Check = puzzlePlatform2.GetComponent<ColliderDetector>().collided;
        puzzlePlatform3Check = puzzlePlatform3.GetComponent<ColliderDetector>().collided;

        if(puzzlePlatform1Check && puzzlePlatform2Check && puzzlePlatform3Check)
        {
            allCheck = true;
            float step = gateSpeed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -4, transform.position.z), step);
        }
        else
        {
            allCheck = false;
        }

    }
}
