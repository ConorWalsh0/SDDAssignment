using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{

	//TODO: Create parent class 'Enemy' with shared behaviours for use in OnCollision in player scripts

	private Rigidbody2D rb2D;
	public Animator animator;
	private RaycastHit2D raycastHit;
	private GameObject Player1;
	private int enemyHealth;
	public int enemyDamage;
	private int ability0_1Damage;
	private float invincibilityTime;
	private float attackDelay;
	private float enemySpeed;
	private float enemyJumpHeight;
	private float enemyTargetDirection;
	private bool facingRight;
	private float knockback;
	private bool isJumping;
	private bool attackMode;

	void Awake()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		Player1 = GameObject.Find("FighterClass");
		ability0_1Damage = Player1.GetComponent<Ability0_1>().ability0_1Damage;
		invincibilityTime = 0f;
		enemyHealth = 100;
		enemyDamage = 30;
		enemySpeed = 110f;
		enemyJumpHeight = 120f;
		enemyTargetDirection = 1f;
		facingRight = true;
		knockback = 50f;
		isJumping = true;
		attackMode = false;
	}

	void FixedUpdate()
	{
		if (enemyTargetDirection > 0f)
		{
			
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, ~LayerMask.NameToLayer("Enemies"));
			raycastHit = hit;
		}
		else
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, ~LayerMask.NameToLayer("Enemies"));
			raycastHit = hit;
		}
	}

	void Update()
	{
		if (invincibilityTime > 0f)
		{
			invincibilityTime -= Time.deltaTime;
		}

		if (raycastHit.collider != null)
		{
			if (raycastHit.collider.CompareTag("Platform") && raycastHit.distance < 1.8f && attackMode && !isJumping)
			{
				Jump();
			}
			else if (raycastHit.collider.CompareTag("Platform") && raycastHit.distance < 1f && !attackMode)
            {
				Flip();
			}

			if (raycastHit.rigidbody != null)
			{
				if (raycastHit.rigidbody.CompareTag("PlayerHurtbox") && raycastHit.distance < 2f && attackDelay <= 0f)
				{
					Attack();
				}
			}
		}

		if (attackDelay > 0f)
		{
			attackDelay -= Time.deltaTime;
		}

		if (!isJumping && !attackMode)
		{
			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}

		if (!isJumping && attackMode)
        {
			Vector2 playerPos = Player1.transform.position;
			Vector2 origin = gameObject.transform.position;
			Vector2 direction = playerPos - origin;
			direction.Normalize();
			enemyTargetDirection = Mathf.Round(direction.x * Mathf.Abs(1 / direction.x));

			if (facingRight && enemyTargetDirection == -1)
            {
				Flip();
            }
			else if (!facingRight && enemyTargetDirection == 1)
            {
				Flip();
			}

			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}

		if (isJumping && facingRight)
        {
			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * 0.1f * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}
		else if (isJumping)
		{
			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * 0.1f * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.collider.tag == "Platform")
		{
			isJumping = false;
		}

		if (collision.collider.tag == "PlayerHitbox" && invincibilityTime <= 0f)
		{
			Debug.Log("Enemy damaged by " + collision.collider.name);
			enemyHealth -= ability0_1Damage;

			if (enemyHealth <= 0)
			{
				Destroy(gameObject);
			}

			invincibilityTime = 0.4f;
			Debug.Log(enemyHealth);

			Vector2 playerPos = collision.transform.position;
			Vector2 origin = gameObject.transform.position;
			Vector2 direction = origin - playerPos;
			direction.Normalize();
			direction.y += 1f;
			rb2D.AddForce(new Vector2(knockback * direction.x, knockback * direction.y), ForceMode2D.Impulse);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			isJumping = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "PlayerHurtbox")
        {
			attackMode = true;
        }
    }

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PlayerHurtbox")
		{
			attackMode = false;
		}
	}

	void Flip()
	{
		Vector3 currentScale = gameObject.transform.localScale;
		currentScale.x *= -1;

		if (!attackMode)
        {
			enemyTargetDirection *= -1;
		}
		
		gameObject.transform.localScale = currentScale;
		facingRight = !facingRight;
	}

	void Attack()
	{
		animator.SetTrigger("Enemy1Attack");
		attackDelay = 0.4f;
	}

	void Jump()
    {
		rb2D.AddForce(new Vector2(20f * enemyTargetDirection, enemyJumpHeight), ForceMode2D.Impulse);
		isJumping = true;
	}
}
