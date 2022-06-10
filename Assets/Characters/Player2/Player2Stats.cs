using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Stats : Players
{
	//general stats
	private float invincibilityTime = 0;

	//Healing info
	public int particleHealth;
	private int partialHeal;

	//external objects

	private Rigidbody2D rb2D;
	private char Player2Class;
	private GameObject HPBarFront2;

	public void FighterSelected()
	{
		Debug.Log("FighterSelected");
	}

	public void WizardSelected()
	{
		Debug.Log("WizardSelected");
	}

	public void RogueSelected()
	{
		Debug.Log("RogueSelected");
	}

	void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		Player2Class = GameObject.Find("CharacterCreation").GetComponent<CharacterCreation>().player2CharacterSelect;
		HPBarFront2 = GameObject.Find("HPBarFront2");

		this.maxPlayerHealth = 100;
		this.playerHealth = maxPlayerHealth;
		this.particleHealth = 5;
		this.playerDamage = 30;
		this.playerSpeedModifier = 1f;
		this.playerArmour = 0;
		this.knockback = 50f;
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
		if (collision.collider.tag == "Enemy1Hitbox" && invincibilityTime <= 0f)
		{
			Knockback(collision, gameObject, rb2D, knockback, playerSpeedModifier);

			playerHealth = PlayerDamageTaken(collision, gameObject, playerArmour, playerHealth, maxPlayerHealth);

			HealthBarUpdate();

			Debug.Log("Player damaged by " + collision.collider.name);
			invincibilityTime = 0.4f;
			Debug.Log(playerHealth);
		}
	}

	void HealthBarUpdate()
	{
		HPBarFront2.GetComponent<Image>().fillAmount = ((float)playerHealth / (float)maxPlayerHealth);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "LevelGoal")
		{
			LevelFinish();
		}
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
		HealthBarUpdate();
	}

	public void Ability2_1Unlock()
	{
		gameObject.GetComponent<Ability2_1>().enabled = true;
	}

}
