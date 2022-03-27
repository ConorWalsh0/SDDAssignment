using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability0_1 : MonoBehaviour
{
    public Animator animator;
    private Controls controls;
    private int player1Damage;
    public int ability0_1Damage;
    private float delay = 0f;

    void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Ability0_1.performed += Ability0_1Performed;
    }

    void Start()
    {
        player1Damage = gameObject.GetComponent<Player1Stats>().playerDamage;
        ability0_1Damage = player1Damage;
    }

    void Update()
    {
        if (delay > 0f)
        {
            delay -= Time.deltaTime;
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    
    void Ability0_1Performed(InputAction.CallbackContext context)
    {
        if (delay <= 0f)
        {
            animator.SetTrigger("Ability0_1");
            delay = 0.4f;
        }
    }
}
