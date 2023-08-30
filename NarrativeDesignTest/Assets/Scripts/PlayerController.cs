using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build;

public class PlayerController : MonoBehaviour
{
    //Variables for speed and camera sensitivity
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;



    //Private variables for Character controller
    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 movement;



    //Variable contains information from the previous
    private float verticalVelocity;
    public Transform shell;



    // Start is called before the first frame update
    void Start()
    {
        //Get the character controller component from this object
        characterController = GetComponent<CharacterController>();
        //Get the camera component from the child object
        playerCamera = GetComponentInChildren<Camera>();

    }



    // Update is called once per frame
    void Update()
    {



        //PLAYER MOVEMENT
        //handle horizontal movement
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        //Handle movement using the above variables on the Character controller
        movement = transform.right * horizontalMovement;



        //Jump
        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            //Add gravity when not grounded
            verticalVelocity += gravity * Time.deltaTime;
        }



        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            //Accessing just the y value of the Vector3
            verticalVelocity = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
        movement.y = verticalVelocity * Time.deltaTime;



        //Check if we press spacebar

        characterController.Move(movement);


    }
}