using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    private CharacterController cc;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") == 1)
        {
            MoveForward();
        }
        
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            TurnRight();
        }else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            TurnLeft();
        }       
    }

    private void MoveForward()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void MoveBackward()
    {

    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, 0 - rotationSpeed);
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, rotationSpeed);
    }

    private void MoveLeft()
    {

    }

    private void MoveRight()
    {

    }

    private void Jump()
    {

    }

    private void DodgeRoll()
    {

    }

    private void AttackLeftArm()
    {

    }

    private void AttackRightArm()
    {

    }

    private void AttackLeftLeg()
    {

    }

    private void AttackRightLeg()
    {

    }

    private void LIMBHighJump()
    {

    }

    private void LIMBGroundPound()
    {

    }

    private void LIMBShoulderTackle()
    {

    }

    private void Interact()
    {

    }
}