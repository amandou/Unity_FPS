using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    private float gravity = -9.8f;
    private Vector3 velocity;

    [SerializeField]
    private float horizontalMovement;
    [SerializeField]
    private float verticalMovement;
    
    
    public float speed;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Movement();
        GravityHandler();
    }

    void GravityHandler()
    {
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontalMovement + transform.forward * verticalMovement;
        playerController.Move(direction * speed * Time.deltaTime);
    }

}
