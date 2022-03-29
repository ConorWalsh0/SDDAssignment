using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability2_1 : MonoBehaviour
{
    private Controls controls;

    void OnEnable()
    {
        GetComponent<Ability1_1>().Ability1_1Deselected();
        controls = new Controls();
        controls.Gameplay.Enable();
        controls.Gameplay.Ability2_1.performed += Ability2_1Performed;
    }

    void Start()
    {
        
    }

    void OnDisable()
    {
        Debug.Log("Ability 2 no");
        controls.Gameplay.Ability2_1.performed -= Ability2_1Performed;
    }

    void Update()
    {
        
    }

    void Ability2_1Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Ability 2");
    }

}
