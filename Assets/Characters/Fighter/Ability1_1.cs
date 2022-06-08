using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_1 : MonoBehaviour
{
	private ParticleSystem particleSys;
	private Controls controls;
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

	void Start()
	{
		controls = new Controls();
		controls.Gameplay.Enable();
		particleSys = GetComponent<ParticleSystem>();
		invincibilityTime = 0f;
	}

	void Update()
    {
		if (invincibilityTime > 0)
		{
			invincibilityTime -= Time.deltaTime;
		}
	}

	void Ability1_1Performed(InputAction.CallbackContext context)
	{
		playerHealth = GetComponent<Player1Stats>().playerHealth;
		maxPlayerHealth = GetComponent<Player1Stats>().maxPlayerHealth;
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

	public void HealthParticleEmission()
    {
		playerHealth = GetComponent<Player1Stats>().playerHealth;
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
		if (collision.collider.tag == "EnemyHitbox" && invincibilityTime <= 0f)
		{
			HealthParticleEmission();
			invincibilityTime = 0.4f;
		}
	}

			void OnParticleTrigger()
	{
		List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
		int numEnter = particleSys.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

		for (int i = 0; i < numEnter; i++)
		{
			ParticleSystem.Particle p = enter[i];
			ClosestPlayer(p.position);
			Debug.Log(closestPlayer);

			playerHealth = GetComponent<Player1Stats>().playerHealth;
			maxPlayerHealth = GetComponent<Player1Stats>().maxPlayerHealth;

			if (playerHealth < maxPlayerHealth)
            {
				p.remainingLifetime = 0f;
				GetComponent<Player1Stats>().ParticleHeal();
			}
			enter[i] = p;
		}

		particleSys.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
	}

	char ClosestPlayer(Vector3 particlePosition)
    {
		//Unable to get specific collider from each trigger using particle trigger module, hence this workaround
		//Finds closest player to particle
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
