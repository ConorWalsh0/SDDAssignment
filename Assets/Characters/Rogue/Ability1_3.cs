using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_3 : MonoBehaviour
{
    public Animator animator;
    private GameObject LvlStartPlayer1;
    private GameObject LvlStartPlayer2;
    private GameObject MainCamera;
    private Controls controls;
    private float delay;
    private bool facingRight;

    void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Enable();
    }

    public void Ability1_3Setup()
    {
        MainCamera = GameObject.Find("Main Camera");
        LvlStartPlayer1 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer1;
        LvlStartPlayer2 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer2;
    }

    void Start()
    {
        delay = 0f;
        facingRight = true;
    }

    void Update()
    {
        if (delay > 0f)
        {
            delay -= Time.deltaTime;
        }
    }

    public void Ability1_3Selected()
    {
        if (LvlStartPlayer1 == gameObject)
        {
            controls.Gameplay.Ability1_3_1.performed += Ability1_3Performed;
        }
        else
        {
            controls.Gameplay.Ability1_3_2.performed += Ability1_3Performed;
        }
    }

    void Ability1_3Performed(InputAction.CallbackContext context)
    {
        if (delay <= 0f)
        {
            animator.SetTrigger("Ability1_3");

            if (LvlStartPlayer1 == gameObject)
            {
                facingRight = LvlStartPlayer1.GetComponent<Player1Movement>().facingRight;
            }
            else
            {
                facingRight = LvlStartPlayer2.GetComponent<Player2Movement>().facingRight;
            }

            if (facingRight) //reverses horizontal force if character is facing left
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(40f, 90f), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-40f, 90f), ForceMode2D.Impulse);
            }

            delay = 0.4f;
        }
    }
}
