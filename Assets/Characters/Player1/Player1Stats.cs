using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Stats : MonoBehaviour
{
	public int playerHealth;
	public int maxPlayerHealth;
	public int particleHealth;
	public int playerDamage;
	private int playerArmour;
	public float playerSpeedModifier;
	private float invincibilityTime = 0;
	private float knockback;

	private GameObject RespawnPoint;
	private GameObject Menu_LevelUp1;
	private GameObject Enemy1;
	private int enemy1Damage;
	private Rigidbody2D rb2D;

	void Awake()
	{
		maxPlayerHealth = 100;
		playerHealth = maxPlayerHealth;
		particleHealth = 5;
		playerDamage = 30;
		playerSpeedModifier = 1f;
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		Menu_LevelUp1 = GameObject.Find("Menu_LevelUp1");
		Menu_LevelUp1.SetActive(false);
		RespawnPoint = GameObject.Find("RespawnPoint");
		playerArmour = 0;
		knockback = 50f;
		Enemy1 = GameObject.Find("Enemy1");
		enemy1Damage = Enemy1.GetComponent<Enemy1Behaviour>().enemyDamage;
	}

	void Update()
	{
		if (invincibilityTime > 0f)
		{
			invincibilityTime -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "EnemyHitbox" && invincibilityTime <= 0f)
		{
			if (enemy1Damage - playerArmour < 0)
			{
				playerHealth -= 1;
			}
			else
			{
				playerHealth -= (enemy1Damage - playerArmour);
			}

			if (playerHealth <= 0)
			{
				gameObject.SetActive(false);
				GameOver();
			}

			Debug.Log("Player damaged by " + collision.collider.name);
			invincibilityTime = 0.4f;
			Debug.Log(playerHealth);

			//Knockback
			Vector2 enemyPos = collision.transform.position;
			Vector2 origin = gameObject.transform.position;
			Vector2 direction = origin - enemyPos;
			direction.Normalize();
			direction.y += 1f;
			rb2D.AddForce(new Vector2(knockback * direction.x * playerSpeedModifier, knockback * direction.y * playerSpeedModifier), ForceMode2D.Impulse);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "LevelGoal")
        {
			LevelFinished();
        }
    }

	void GameOver()
    {
		playerHealth = maxPlayerHealth;
		RespawnPoint.GetComponent<Respawn>().PlayerRespawn();
	}

	void LevelFinished()
    {
		Debug.Log("yay");
		Menu_LevelUp1.SetActive(true);
    }

	public void Ability1_1Unlock()
    {
		gameObject.GetComponent<Ability1_1>().enabled = true;
    }

	public void Ability2_1Unlock()
	{
		gameObject.GetComponent<Ability2_1>().enabled = true;
	}
}
