using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : Enemy
{
	void Awake()
	{
		this.rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		this.invincibilityTime = 0f;
		this.enemyHealth = 100;
		this.enemyDamage = 30;
		this.enemySpeed = 110f;
		this.enemyJumpHeight = 120f;
		this.enemyTargetDirection = 1f;
		this.facingRight = true;
		this.knockback = 50f;
		this.isJumping = true;
		this.attackMode = false;
		this.Player1 = GameObject.Find("EnemyManager").GetComponent<Enemy>().Player1;
		this.Player2 = GameObject.Find("EnemyManager").GetComponent<Enemy>().Player2;
	}

	void FixedUpdate()
	{
		GroundRaycast(enemyTargetDirection);
	}

	void Update()
	{
		if (invincibilityTime > 0f)
		{
			invincibilityTime -= Time.deltaTime;
		}

		GroundBehaviour(raycastHit, attackMode, isJumping, gameObject, attackModeTarget);
		
		if (raycastHit.collider != null)
		{
			if (raycastHit.collider.CompareTag("Platform") && raycastHit.distance < 1.8f && attackMode && !isJumping)
			{
				Jump(enemyTargetDirection, enemyJumpHeight);
			}
			else if (raycastHit.collider.CompareTag("Platform") && raycastHit.distance < 1f && !attackMode)
			{
				Flip(gameObject);
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
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Platform")
		{
			isJumping = false;
		}

		if (collision.collider.tag == "PlayerHitbox" && invincibilityTime <= 0f)
		{
			EnemyDamageTaken(collision, gameObject, Player1, Player2, enemyHealth);

			if (enemyHealth <= 0)
			{
				Destroy(gameObject);
			}

			invincibilityTime = 0.4f;
			Debug.Log(enemyHealth);

			Knockback(collision, gameObject, rb2D, knockback);
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
			if (attackMode)
			{
				return;
			}
			attackMode = true;
			attackModeTarget = collision.gameObject;
		}
    }

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "PlayerHurtbox")
		{
			attackMode = false;
		}
	}

	void Attack()
	{
		animator.SetTrigger("Enemy1Attack");
		attackDelay = 0.4f;
	}
}
