using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability0_2 : MonoBehaviour
{
    public Animator animator;
    private Controls controls;
    private int playerDamage;
    public int ability0_2Damage;
    private float delay;
    private GameObject LvlStartPlayer1;
    private GameObject MainCamera;
    public InputActionReference triggerAction2;

    void Awake()
    {
        controls = new Controls();
    }

    public void Ability0_2Setup()
    {
        MainCamera = GameObject.Find("Main Camera");
        LvlStartPlayer1 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer1;
        if (LvlStartPlayer1 == gameObject)
        {
            playerDamage = gameObject.GetComponent<Player1Stats>().playerDamage;
            controls.Gameplay.Ability0_2_1.performed += Ability0_2Performed;
        }
        else
        {
            playerDamage = gameObject.GetComponent<Player2Stats>().playerDamage;
            controls.Gameplay.Ability0_2_2.performed += Ability0_2Performed;
        }
    }

    void Start()
    {
        ability0_2Damage = playerDamage;
        delay = 0f;
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

    void Ability0_2Performed(InputAction.CallbackContext context)
    {
        if (delay <= 0f)
        {
            animator.SetTrigger("Ability0_1");
            delay = 0.4f;
        }
    }
}
