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
	private Vector2 FighterPosition;
	private Vector2 WizardPosition;
	private Vector2 RoguePosition;

	void Start()
	{
		controls = new Controls();
		controls.Gameplay.Enable();
		particleSys = GetComponent<ParticleSystem>();
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

	void OnParticleTrigger()
	{
		List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
		int numEnter = particleSys.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

		for (int i = 0; i < numEnter; i++)
		{
			ParticleSystem.Particle p = enter[i];

			//Unable to get specific collider from each trigger using trigger module, hence this workaround
			FighterPosition = particleSys.trigger.GetCollider(0).gameObject.transform.position;
			WizardPosition = particleSys.trigger.GetCollider(1).gameObject.transform.position;
			RoguePosition = particleSys.trigger.GetCollider(2).gameObject.transform.position;

			Debug.Log(particleSys.trigger.GetCollider(0).gameObject.transform.position - p.position);


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
}
