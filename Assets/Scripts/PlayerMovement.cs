using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	
	public float speed = 2f;
	public float gravity = -9.81f;
	public float jumpHeight = 1f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

    void Update()
    {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0) {
			velocity.y = -2f;
		}

        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		var h = transform.right * x;
		var f = transform.forward * z;

		Vector3 move = h + f; 

		controller.Move(move * speed * Time.deltaTime);

		if(Input.GetButtonDown("Jump") && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
    }
}
