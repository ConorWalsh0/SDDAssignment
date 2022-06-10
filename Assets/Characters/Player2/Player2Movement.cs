using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{
	private Rigidbody2D _rb2D;
	private float playerSpeed = 150.0f;
	private float jumpHeight = 100.0f;
	private bool isJumping = false;
	private Vector2 moveHorizontal;
	private Controls controls;
	private float xComponent;
	private bool facingRight = true;
	private float speedModifier;
	private float jumpModifier;

	void Awake()
	{
		controls = new Controls();
		_rb2D = gameObject.GetComponent<Rigidbody2D>();
		controls.Gameplay.Jump2.performed += JumpPerformed;
	}

	void Start()
	{
		speedModifier = gameObject.GetComponent<Player2Stats>().playerSpeedModifier;

	}

	void OnEnable()
	{
		controls.Gameplay.Enable();
	}

	void Update()
	{
		moveHorizontal = controls.Gameplay.Movement2.ReadValue<Vector2>();
		if (moveHorizontal != Vector2.zero)
		{
			xComponent = moveHorizontal.x;
			_rb2D.AddForce(new Vector2(xComponent * playerSpeed * speedModifier * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}

		if (moveHorizontal.x < 0f && facingRight)
		{
			Flip();
		}

		if (moveHorizontal.x > 0f && !facingRight)
		{
			Flip();
		}
	}

	void Flip()
	{
		Vector3 currentScale = gameObject.transform.localScale;
		currentScale.x *= -1;
		gameObject.transform.localScale = currentScale;
		facingRight = !facingRight;
	}

	void JumpPerformed(InputAction.CallbackContext context)
	{
		if (!isJumping)
		{
			_rb2D.AddForce(new Vector2(0f, jumpHeight * speedModifier), ForceMode2D.Impulse);
			playerSpeed *= 0.8f;
			isJumping = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			playerSpeed = 150.0f;
			isJumping = false;
		}
	}
}
