using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Movement();

    }

    private void FixedUpdate()
    {
        rb.AddForce(Movement() * moveSpeed);
    }

    private Vector3 Movement()
    {
        Vector3 moveInput = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
            moveInput += Vector3.left;
        if (Input.GetAxisRaw("Horizontal") > 0)
            moveInput -= Vector3.left;
        if (Input.GetAxisRaw("Vertical") > 0)
            moveInput += Vector3.forward;
        if (Input.GetAxisRaw("Vertical") < 0)
            moveInput -= Vector3.forward;

        return moveInput.normalized;
    }
}
