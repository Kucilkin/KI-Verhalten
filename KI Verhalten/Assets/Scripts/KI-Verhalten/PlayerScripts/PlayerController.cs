using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float sprintSpeedMultiplier;
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

        moveInput += transform.right * Input.GetAxisRaw("Horizontal");
        moveInput += transform.forward * Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            moveSpeed *= sprintSpeedMultiplier;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeed /= sprintSpeedMultiplier;

        return moveInput.normalized;    //Normalize directional Vector to ensure walking speed doesn't change depending on input
    }

    
    

}
