using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce = 10;
    public float numJumps = 2;
    public int scoreval = 0;
    public TMPro.TMP_Text score;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool grounded = true;
    private int JumpsUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        score.SetText("Score:" + scoreval);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJump()
    {
        if (grounded)
        {
            Jump();
            JumpsUsed += 1;
            grounded = false;
        }
        else if( JumpsUsed < numJumps)
        {
            Jump();
            JumpsUsed += 1;
        }

    }

    private void FixedUpdate()
    {
        if (transform.position.y < -5){
            transform.position = new Vector3(-26f, 5, -14.5f);
        }
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            scoreval += 200;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BadPickUp"))
        {
            scoreval -= 200;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            JumpsUsed = 0;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
        Debug.Log(Vector3.up * jumpForce);
    }
}