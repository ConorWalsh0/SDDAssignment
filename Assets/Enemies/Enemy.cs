using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Rigidbody2D rb2D;
	public Animator animator;
	public RaycastHit2D raycastHit;
	public int enemyHealth;
	public int enemyDamage;
	public float invincibilityTime;
	public float attackDelay;
	public float enemySpeed;
	public float enemyJumpHeight;
	public bool facingRight;
	public float knockback;
	public bool isJumping;
	public bool attackMode;
	public GameObject attackModeTarget;
	public float enemyTargetDirection;
	public GameObject Player1;//Player1 & 2 assigned value on level start in LevelManager
	public GameObject Player2;//

	public int EnemyDamageTaken(Collision2D collision, GameObject enemyGameObject, GameObject Player1, GameObject Player2, int enemyHealth)
	{
		Debug.Log(enemyGameObject + "damaged by " + collision.gameObject);
		if (collision.gameObject == Player1)
		{
			enemyHealth -= Player1.GetComponent<Player1Stats>().playerDamage;
		}
		else
		{
			enemyHealth -= Player2.GetComponent<Player2Stats>().playerDamage;
		}
		return enemyHealth;
	}

	public void Knockback(Collision2D collision, GameObject enemyGameObject, Rigidbody2D rb2D, float knockback)
	{
		Vector2 playerPos = collision.transform.position;
		Vector2 origin = gameObject.transform.position;
		Vector2 direction = origin - playerPos;
		direction.Normalize();
		direction.y += 1f;
		rb2D.AddForce(new Vector2(knockback * direction.x, knockback * direction.y), ForceMode2D.Impulse);
	}

	public RaycastHit2D GroundRaycast(float enemyTargetDirection)
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

		return raycastHit;
	}

	public void GroundBehaviour(RaycastHit2D raycastHit, bool attackMode, bool isJumping, GameObject enemyGameObject, GameObject attackModeTarget)
	{
		if (isJumping)
		{
			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * 0.1f * Time.deltaTime, 0f), ForceMode2D.Impulse);
			return;
		}

		if (!attackMode)
		{
			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}
		else
		{
			Vector2 targetPos = attackModeTarget.transform.position;
			Vector2 origin = enemyGameObject.transform.position;
			Vector2 direction = targetPos - origin;
			direction.Normalize();
			enemyTargetDirection = Mathf.Round(direction.x * Mathf.Abs(1 / direction.x));

			if (facingRight && enemyTargetDirection == -1)
			{
				Flip(enemyGameObject);
			}
			else if (!facingRight && enemyTargetDirection == 1)
			{
				Flip(enemyGameObject);
			}

			rb2D.AddForce(new Vector2(enemySpeed * enemyTargetDirection * Time.deltaTime, 0f), ForceMode2D.Impulse);
		}
	}

	public bool Flip(GameObject enemyGameObject)
	{
		Vector3 currentScale = enemyGameObject.transform.localScale;
		currentScale.x *= -1;

		if (!attackMode)
		{
			enemyTargetDirection *= -1;
		}

		enemyGameObject.transform.localScale = currentScale;
		facingRight = !facingRight;
		return facingRight;
	}

	public bool Jump(float enemyTargetDirection, float enemyJumpHeight)
	{
		rb2D.AddForce(new Vector2(20f * enemyTargetDirection, enemyJumpHeight), ForceMode2D.Impulse);
		isJumping = true;
		return isJumping;
	}
}
