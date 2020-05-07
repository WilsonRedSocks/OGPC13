using UnityEngine;
using System.Collections;
using System.Configuration;

public class Movement : MonoBehaviour
{
    //create the player
    [SerializeField] private CharacterController player;

    //create the speed of movement
    [SerializeField] private float speed = 25f;
    [SerializeField] private float SprintMultiplier = 2f;

    //jump height float
    [SerializeField] private float height;

    //create the player gravity
    [SerializeField] private float gravity;

    //create the gravity velocity of the player
    [SerializeField] private Vector3 velocity;

    //create the ground checker
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float gdist = 0.05f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float terminalv;
    
    void FixedUpdate()
    {
        //reset velocity on ground
        if (onground())
        {
            velocity.y = -0.2f;
        }

        //get the wsad inputs for the frame
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //calculate the movement for the frame
        Vector3 move = transform.right * x + transform.forward * z;

        //move the player
        if(Input.GetButton("Sprint"))
        {
            player.Move(move * speed * SprintMultiplier * Time.deltaTime);
        }
        else
        {
            player.Move(move * speed * Time.deltaTime);
        }

        //jump
        if(Input.GetButton("Jump") && onground())
        {
            //set the jump velocity
            velocity.y = Mathf.Sqrt(height * -2f * gravity);
        }

        //add gravity
        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);

        //set terminal velocity
        velocity.y = Mathf.Clamp(velocity.y, -50f, 100f);
    }

    //create the ground check function
    bool onground()
    {
        return Physics.CheckSphere(groundcheck.transform.position, gdist);
    }
}
