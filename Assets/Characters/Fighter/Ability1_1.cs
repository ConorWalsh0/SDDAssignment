using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_1 : MonoBehaviour
{
	private ParticleSystem particleSys;
	private Controls controls;
	private GameObject Player1;
	private GameObject Player2;
	private int playerHealth;
	private int maxPlayerHealth;
	private int damageParticleNum;
	private int abilityParticleNum;
	private float FighterDistance;
	private float WizardDistance;
	private float RogueDistance;
	private char closestPlayer;
	private float minDistance;
	private float invincibilityTime;
	private GameObject FighterClass;
	private GameObject WizardClass;
	private GameObject RogueClass;
	private GameObject CharacterCreation;

	void Start()
	{
		controls = new Controls();
		controls.Gameplay.Enable();
		particleSys = GetComponent<ParticleSystem>();
		invincibilityTime = 0f;
	}

	public void Ability1_1Setup()
    {
		if (gameObject.GetComponent<Player1Stats>() != null)
		{
			Player1 = this.gameObject;
		}
		else if (gameObject.GetComponent<Player2Stats>() != null)
		{
			Player2 = this.gameObject;
		}
		else
		{
			Debug.Log("Fighter not selected");
		}

		FighterClass = GameObject.Find("FighterClass");
		WizardClass = GameObject.Find("WizardClass");
		RogueClass = GameObject.Find("RogueClass");
		CharacterCreation = GameObject.Find("CharacterCreation");
	}

	void Update()
    {
		if (invincibilityTime > 0)
		{
			invincibilityTime -= Time.deltaTime;
		}
	}

	//Creates number of health particles that is closest integer of player's max health divided by 20
	//If player health is below 10% of max player health, a single health particle is emitted
	void Ability1_1Performed(InputAction.CallbackContext context)
	{
		if (Player1 == this.gameObject)
        {
			playerHealth = GetComponent<Player1Stats>().playerHealth;
			maxPlayerHealth = GetComponent<Player1Stats>().maxPlayerHealth;
		}
		else if (Player2 == this.gameObject)
		{
			playerHealth = GetComponent<Player2Stats>().playerHealth;
			maxPlayerHealth = GetComponent<Player2Stats>().maxPlayerHealth;
		}
        else
        {
			Debug.Log("Ability1_1 attempted to fire, but no player is assigned fighter class");
        }

		if (playerHealth > maxPlayerHealth * 0.1f)
        {
			float maxPlayerHealthFloat = (float)maxPlayerHealth;
			abilityParticleNum = Mathf.RoundToInt(maxPlayerHealth / 20);
			particleSys.Emit(abilityParticleNum);
			GetComponent<Player1Stats>().Ability1_1Used();
		}
        else
        {
			abilityParticleNum = 1;
			particleSys.Emit(abilityParticleNum);
			GetComponent<Player1Stats>().Ability1_1Used();
		}
	}

	//Emits number of health particles equal to 80% of current health, divided by 20.
	public void HealthParticleEmission()
    {
		if (gameObject.GetComponent<Player1Stats>().isActiveAndEnabled)
        {
			playerHealth = gameObject.GetComponent<Player1Stats>().playerHealth;
		}
		else if (gameObject.GetComponent<Player2Stats>().isActiveAndEnabled)
        {
			playerHealth = gameObject.GetComponent<Player2Stats>().playerHealth;
		}
        else
        {
			Debug.Log("Fighter not selected by player 1 or 2");
        }

		damageParticleNum = Mathf.RoundToInt(playerHealth * 0.8f / 20);
		particleSys.Emit(damageParticleNum);
	}

	public void Ability1_1Selected()
    {
		controls.Gameplay.Ability1_1.performed += Ability1_1Performed;
	}

	public void Ability1_1Deselected()
    {
		controls.Gameplay.Ability1_1.performed -= Ability1_1Performed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Enemy1Hitbox" && invincibilityTime <= 0f)
		{
			HealthParticleEmission();
			invincibilityTime = 0.4f;
		}
	}

	//for each particle that collides with a player gameObject, the closest player is found, and healed if they don't have max health
	void OnParticleTrigger()
	{
		List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
		int numEnter = particleSys.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

		for (int i = 0; i < numEnter; i++)
		{
			ParticleSystem.Particle p = enter[i];
			ClosestPlayer(p.position);

			//Accesses health info from the closest player to the health particle
			if (CharacterCreation.GetComponent<CharacterCreation>().player1CharacterSelect == closestPlayer) //Could use lvlStartPlayer1/2 and a check on active components instead
            {
				switch (closestPlayer)
                {
					case 'f':
						playerHealth = FighterClass.GetComponent<Player1Stats>().playerHealth;
						maxPlayerHealth = FighterClass.GetComponent<Player1Stats>().maxPlayerHealth;
						break;
					case 'w':
						playerHealth = WizardClass.GetComponent<Player1Stats>().playerHealth;
						maxPlayerHealth = WizardClass.GetComponent<Player1Stats>().maxPlayerHealth;
						break;
					case 'r':
						playerHealth = RogueClass.GetComponent<Player1Stats>().playerHealth;
						maxPlayerHealth = RogueClass.GetComponent<Player1Stats>().maxPlayerHealth;
						break;
				}
			}

			if (CharacterCreation.GetComponent<CharacterCreation>().player2CharacterSelect == closestPlayer)
			{
				switch (closestPlayer)
				{
					case 'f':
						playerHealth = FighterClass.GetComponent<Player2Stats>().playerHealth;
						maxPlayerHealth = FighterClass.GetComponent<Player2Stats>().maxPlayerHealth;
						break;
					case 'w':
						playerHealth = WizardClass.GetComponent<Player2Stats>().playerHealth;
						maxPlayerHealth = WizardClass.GetComponent<Player2Stats>().maxPlayerHealth;
						break;
					case 'r':
						playerHealth = RogueClass.GetComponent<Player2Stats>().playerHealth;
						maxPlayerHealth = RogueClass.GetComponent<Player2Stats>().maxPlayerHealth;
						break;
				}
			}
			
			if (playerHealth < maxPlayerHealth) //Checks if player can be healed, then deletes the healing particle and initiates healing on the appropriate player
            {
				p.remainingLifetime = 0f;
				switch (closestPlayer)
                {
					case 'f':
						if (FighterClass.GetComponent<Player1Stats>() != null)
                        {
							FighterClass.GetComponent<Player1Stats>().ParticleHeal();
						}
                        else
                        {
							FighterClass.GetComponent<Player2Stats>().ParticleHeal();
						}
						break;
					case 'w':
						if (WizardClass.GetComponent<Player1Stats>() != null)
						{
							WizardClass.GetComponent<Player1Stats>().ParticleHeal();
						}
						else
						{
							WizardClass.GetComponent<Player2Stats>().ParticleHeal();
						}
						break;
					case 'r':
						if (RogueClass.GetComponent<Player1Stats>() != null)
						{
							RogueClass.GetComponent<Player1Stats>().ParticleHeal();
						}
						else
						{
							RogueClass.GetComponent<Player2Stats>().ParticleHeal();
						}
						break;
				}
			}
			enter[i] = p;
		}
		particleSys.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
	}

	char ClosestPlayer(Vector3 particlePosition)
    {
		//Unable to get specific collider from each trigger using particle trigger module, hence this workaround
		//Finds closest player to particle by comparing the magnitude of the vector between the particle and each player
		FighterDistance = (particleSys.trigger.GetCollider(0).gameObject.transform.position - particlePosition).magnitude;
		WizardDistance = (particleSys.trigger.GetCollider(1).gameObject.transform.position - particlePosition).magnitude;
		RogueDistance = (particleSys.trigger.GetCollider(2).gameObject.transform.position - particlePosition).magnitude;
		minDistance = Mathf.Min(FighterDistance, WizardDistance, RogueDistance);

		if (minDistance == FighterDistance)
        {
			closestPlayer = 'f';
        }
		else if (minDistance == WizardDistance)
		{
			closestPlayer = 'w';
		}
        else if (minDistance == RogueDistance)
        {
			closestPlayer = 'r';
        }

		return closestPlayer;
	}
}
