using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_2 : MonoBehaviour
{
    public Animator animator;
    private Controls controls;
    private int playerDamage;
    public int ability1_2Damage;
    private float delay;
    private GameObject LvlStartPlayer1;
    private GameObject LvlStartPlayer2;
    private GameObject MainCamera;
    private GameObject Fireball;
    private float playerDirection;

    void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Ability1_2.performed += Ability1_2Performed;
    }

    public void Ability1_2Setup()
    {
        MainCamera = GameObject.Find("Main Camera");
        Fireball = gameObject.transform.Find("Fireball").gameObject;
        LvlStartPlayer1 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer1;
        LvlStartPlayer2 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer2;

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
        ability1_2Damage = playerDamage;
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

    void Ability1_2Performed(InputAction.CallbackContext context)
    {
        if (delay <= 0f)
        {
            GameObject FireballClone = Instantiate(Fireball, gameObject.transform.position, Quaternion.identity); //Creates copy of fireball with a position relative to WizardClass parent gameObject

            if (LvlStartPlayer1 == gameObject) //Find direction player is facing
            {
                if (LvlStartPlayer1.GetComponent<Player1Movement>().facingRight == true)
                {
                    playerDirection = 1f;
                }
                else
                {
                    playerDirection = -1f;
                }
            }
            else
            {
                if (LvlStartPlayer2.GetComponent<Player2Movement>().facingRight == true)
                {
                    playerDirection = 1f;
                }
                else
                {
                    playerDirection = -1f;
                }
            }

            FireballClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f * playerDirection, 1f), ForceMode2D.Impulse);
            delay = 0.4f;
            Destroy(FireballClone, 4);
        }
    }
}
