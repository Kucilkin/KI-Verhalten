using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed;
    private Vector3 currInput;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        currInput = Movement();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(currInput.x, rb.velocity.y, currInput.z) * moveSpeed;
    }

    private Vector3 Movement()
    {
        Vector3 moveInput = Vector3.zero;

        //if (Input.GetAxisRaw("Horizontal") < 0)
        //    moveInput += transform.right;
        //if (Input.GetAxisRaw("Horizontal") > 0)
        //    moveInput -= transform.right;
        //if (Input.GetAxisRaw("Vertical") > 0)
        //    moveInput += transform.forward;
        //if (Input.GetAxisRaw("Vertical") < 0)
        //    moveInput -= transform.forward;

        moveInput += transform.right * Input.GetAxisRaw("Horizontal");
        moveInput += transform.forward * Input.GetAxisRaw("Vertical");

        //if(moveInput == Vector3.zero)
        //    rb.velocity = Vector3.zero;

        return moveInput.normalized;
    }
}
