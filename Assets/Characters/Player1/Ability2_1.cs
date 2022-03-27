using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ability2_1 : MonoBehaviour
{
    private Controls controls;

    void OnEnable()
    {
        
    }

    void Start()
    {
        controls = new Controls();
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        Debug.Log("Ability 2 no");
    }

    void Update()
    {
        
    }
}
