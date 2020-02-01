using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0;
    private float gravity = 3.0f;
    private float animationDuration = 3.0f;
    void Start()
    { 
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
    }
    public void SetSpeed(int modifier)
    {
        speed = 5.0f + modifier;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");
    }
}



