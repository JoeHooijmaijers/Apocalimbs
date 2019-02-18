using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float movementSpeed;
    public float jumpHeight;
    public float rotationSpeed;

    float distanceToGround;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        Movement();
    }

    void Movement()
    {
        Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0f, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        transform.Translate(targetDirection, Space.World);
        transform.rotation = Quaternion.LookRotation(targetDirection);

        if (Input.GetKey("space"))
        {
            Jump();
        }
    }

    void Jump()
    {
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.0f);

        if (IsGrounded)
        {
            rb.velocity += jumpHeight * Vector3.up;
        }
    }

    void DodgeRoll()
    {

    }

    void RightArmAttack()
    {

    }

    void LeftArmAttack()
    {

    }

    void RightLegAttack()
    {

    }

    void LeftLegAttack()
    {

    }
}
