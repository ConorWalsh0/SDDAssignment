using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability1_3 : MonoBehaviour
{

    private GameObject Player1;
    private GameObject Player2;
    private Controls controls;

    void Awake()
    {
        controls = new Controls();
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
            Debug.Log("Rogue not selected");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
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
        Debug.Log("Ability1_3");
    }
}
