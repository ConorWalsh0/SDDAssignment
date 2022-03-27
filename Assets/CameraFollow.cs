using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public float dampTime = 0.4f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    private Controls controls;
    private Vector2 direction;
    private Vector3 delta;

    void Awake()
    {
        controls = new Controls();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void LateUpdate()
    {
        direction = controls.Gameplay.Movement1.ReadValue<Vector2>();
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);

        if (direction.x > 0f)
        {
            delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.25f, 0.5f, point.z));
        }
        else if (direction.x < 0f) 
        {
            delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.75f, 0.5f, point.z));
        }
        else
        {
            delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        }

        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
