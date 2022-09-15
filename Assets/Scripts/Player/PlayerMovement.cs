using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audio;
    private Vector3 initialPosition;
    private bool isFalling = false;

    public Text pointsText;
    public Canvas finalWindow;
    public Text finalText;

    private bool togglePause = false;

    private float MovementSpeed = 4.0f;
    private int points = 0;
    private int cubeNumber = 7;

    private Vector2 movementValue;
    private bool jump = false;
    public float jumpForce = 6;

    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = rb.transform.position;
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movementDirection = cameraTransform.TransformVector(movementValue);

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

       // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movementDirection.x * MovementSpeed, 0, movementDirection.y * MovementSpeed);

        if (jump && !isFalling)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            isFalling = true;
            jump = false;
        }

        if (togglePause)
        {
            if (!finalWindow.enabled)
            {
                finalWindow.enabled = true;
                finalText.text = "Pause";
                pointsText.enabled = false;
                rb.isKinematic = true;
                Time.timeScale = 0f;
            }
            else
            {
                finalWindow.enabled = false;
                pointsText.enabled = true;
                rb.isKinematic = false;
                Time.timeScale = 1f;
            }
            togglePause = false;
        }

        //isFalling = true;

        if (rb.position.y < -10)
        {
            finalWindow.enabled = true;
            finalText.text = "You lose! Final points: " + points;
            pointsText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            points++;
            pointsText.text = "Points: " + points;
            audio.Play();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            finalWindow.enabled = true;
            finalText.text = "You win! Final points: " + points;
            pointsText.enabled = false;
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            finalWindow.enabled = true;
            finalText.text = "You lose! Final points: " + points;
            pointsText.enabled = false;
            rb.isKinematic = true;
        }

        if (collision.gameObject.CompareTag("RotatingShape"))
        {
            finalWindow.enabled = true;
            finalText.text = "You lose! Final points: " + points;
            pointsText.enabled = false;
            rb.isKinematic = true;
        }

        if (collision.gameObject.CompareTag("FallingCube"))
        {
            finalWindow.enabled = true;
            finalText.text = "You lose! Final points: " + points;
            pointsText.enabled = false;
            rb.isKinematic = true;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        isFalling = false;
    }

    private void OnMove(InputValue value)
    {
        var vector2Value = value.Get<Vector2>();
        movementValue.x = vector2Value.x;
        movementValue.y = vector2Value.y;
    }

    private void OnJump(InputValue value)
    {
        jump = true;
    }

    private void OnTogglePause(InputValue value)
    {
        togglePause = true;
    }
}
