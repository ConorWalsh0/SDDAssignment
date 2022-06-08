using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public float dampTime = 0.4f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 target;
    private Controls controls;
    private Vector2 direction;
    private Vector3 delta;
    public GameObject Menu_LevelUp1;
    private bool cameraMobilised;
    private GameObject Player1;
    private GameObject Player2;

    void Awake()
    {
        controls = new Controls();
    }

    void Start()
    {
        Menu_LevelUp1 = GameObject.Find("Menu_LevelUp1");
        Menu_LevelUp1.SetActive(false);
        cameraMobilised = false;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void LateUpdate()
    {
        if (!cameraMobilised)
        {
            return;
        }

        target = gameObject.GetComponent<Players>().PlayersMidpoint(Player1, Player2);
        direction = controls.Gameplay.Movement1.ReadValue<Vector2>();
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target);

        if (direction.x > 0f)
        {
            delta = target - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.25f, 0.5f, point.z));
        }
        else if (direction.x < 0f) 
        {
            delta = target - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.75f, 0.5f, point.z));
        }
        else
        {
            delta = target - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        }

        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }

    public void CameraMobilised()
    {
        Player1 = gameObject.GetComponent<LevelManager>().LvlStartPlayer1;
        Player2 = gameObject.GetComponent<LevelManager>().LvlStartPlayer2;
        cameraMobilised = true;
    }
}
