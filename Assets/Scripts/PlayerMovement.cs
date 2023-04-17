using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementspeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpsound;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalinput * movementspeed, rb.velocity.y, verticalinput * movementspeed);

        if (Input.GetButtonDown("Jump") && isgrounded())
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpsound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }


    bool isgrounded()
    {
        return Physics.CheckSphere(groundcheck.position, 1f, ground);
    }

}