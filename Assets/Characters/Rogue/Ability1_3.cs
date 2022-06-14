using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_3 : MonoBehaviour
{
    public Animator animator;
    private GameObject Player1;
    private GameObject Player2;
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
            Debug.Log("Rogue not selected");
        }
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
        if (Player1 == gameObject)
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

            if (Player1 == gameObject)
            {
                facingRight = Player1.GetComponent<Player1Movement>().facingRight;
            }
            else
            {
                facingRight = Player2.GetComponent<Player2Movement>().facingRight;
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
