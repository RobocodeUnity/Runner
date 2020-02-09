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
    public GameObject panelGameOver;
    public bool isDead;
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.enabled = true;
        isDead = false;
        panelGameOver.SetActive(false);
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
     //   moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down
        moveVector.y = verticalVelocity;
        if (isDead)
        {
            anim.enabled = false;
            moveVector.z = 0;
        }
        else
        {
            moveVector.z = speed;
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                Debug.Log("Right");
                moveVector.x = speed;
            }
            else
            {
                Debug.Log("Left");
                moveVector.x = -speed;
            }
        }

        controller.Move(moveVector * Time.deltaTime);
    }
    public void SetSpeed(int modifier)
    {
        speed = 5.0f + modifier;
    }
    private void OnTriggerEnter(Collider other)
    {
        isDead = true;
        panelGameOver.SetActive(true);
       // Debug.Log("Test");
    }
    public void RestartScene()
    {
        Application.LoadLevel("Game");
    }

}



