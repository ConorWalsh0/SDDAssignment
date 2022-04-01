using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Stats : MonoBehaviour
{
	//general stats
	public int playerHealth;
	public int maxPlayerHealth;
	public int playerDamage;
	private int playerArmour;
	public float playerSpeedModifier;
	private float invincibilityTime = 0;
	private float knockback;

	//ability 1_1 stats
	public int particleHealth;
	private int partialHeal;

	//external objects
	private GameObject RespawnPoint;
	private GameObject Menu_LevelUp1;
	private GameObject Enemy1;
	private int enemy1Damage;
	private Rigidbody2D rb2D;
	private char Player1Class;

	void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		Menu_LevelUp1 = GameObject.Find("Main Camera").GetComponent<CameraFollow>().Menu_LevelUp1;
		Player1Class = GameObject.Find("CharacterCreation").GetComponent<CharacterCreation>().Player1CharacterSelect;



		maxPlayerHealth = 100;
		playerHealth = maxPlayerHealth;
		particleHealth = 5;
		playerDamage = 30;
		playerSpeedModifier = 1f;

		RespawnPoint = GameObject.Find("RespawnPoint");
		playerArmour = 0;
		knockback = 50f;
		Enemy1 = GameObject.Find("Enemy1");
		enemy1Damage = 1;// Enemy1.GetComponent<Enemy1Behaviour>().enemyDamage;
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
			//Knockback
			Vector2 enemyPos = collision.transform.position;
			Vector2 origin = gameObject.transform.position;
			Vector2 direction = origin - enemyPos;
			direction.Normalize();
			direction.y += 1f;
			rb2D.AddForce(new Vector2(knockback * direction.x * playerSpeedModifier, knockback * direction.y * playerSpeedModifier), ForceMode2D.Impulse);

			gameObject.GetComponent<Ability1_1>().HealthParticleEmission();

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

	public void Ability1_1Used()
    {
		playerHealth -= Mathf.RoundToInt(maxPlayerHealth * particleHealth / 25);
    }

	public void ParticleHeal()
    {
		if ((maxPlayerHealth - playerHealth) < particleHealth)
        {
			partialHeal = particleHealth - (maxPlayerHealth - playerHealth);
			playerHealth += partialHeal;
        }
		else
        {
			playerHealth += particleHealth;
        }
    }

	public void Ability2_1Unlock()
	{
		gameObject.GetComponent<Ability2_1>().enabled = true;
	}
}
