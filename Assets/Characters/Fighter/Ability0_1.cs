using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability0_1 : MonoBehaviour
{
    public Animator animator;
    private Controls controls;
    private int playerDamage;
    public int ability0_1Damage;
    private float delay;
    private GameObject LvlStartPlayer1;
    private GameObject MainCamera;

    void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Ability0_1.performed += Ability0_1Performed;
    }

    public void Ability0_1Setup()
    {
        MainCamera = GameObject.Find("Main Camera");
        LvlStartPlayer1 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer1;
        if (LvlStartPlayer1 == gameObject)
        {
            playerDamage = gameObject.GetComponent<Player1Stats>().playerDamage;
        }
        else
        {
            playerDamage = gameObject.GetComponent<Player2Stats>().playerDamage;
        }
    }

    void Start()
    {
        ability0_1Damage = playerDamage;
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
    
    void Ability0_1Performed(InputAction.CallbackContext context)
    {
        if (delay <= 0f)
        {
            animator.SetTrigger("Ability0_1");
            delay = 0.4f;
        }
    }
}
