using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_1 : MonoBehaviour
{
	private ParticleSystem particleSys;
	private Controls controls;

	void OnEnable()
	{
	}

	void Start()
	{
		controls = new Controls();
		controls.Gameplay.Enable();
		controls.Gameplay.Ability1_1.performed += Ability1_1Performed;
		particleSys = GetComponent<ParticleSystem>();
	}

	void OnDisable()
	{
		Debug.Log("Ability 1 no");
	}

	void Update()
	{
	}

	void Ability1_1Performed(InputAction.CallbackContext context)
	{
		particleSys.Play();
	}

	void OnParticleTrigger()
	{
		//if (ParticlePhysicsExtensions.GetTriggerParticles())
		//{
			//Debug.Log(ParticleSystemTriggerEventType.Enter);
		//}

		/*if (playerHealth < maxPlayerHealth)
        {
			playerHealth += particleHealth;
        }*/
	}
}
