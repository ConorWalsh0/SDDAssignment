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
    private Vector2 player1Movement;
    private Vector2 player2Movement;

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

        if (Player1 == null || Player2 == null)
        {
            return;
        }

        target = gameObject.GetComponent<Players>().PlayersMidpoint(Player1, Player2);

        player1Movement = controls.Gameplay.Movement1.ReadValue<Vector2>();
        player2Movement = controls.Gameplay.Movement2.ReadValue<Vector2>();
        direction = new Vector2((player1Movement.x + player2Movement.x) / 2, (player1Movement.y + player2Movement.y) / 2); //Finds average movement of both players to direct camera sway

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

        Vector3 destination = transform.position + delta; //destination is current position of camera + midpoint of players
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime); //Moves camera to destination smoothly
    }

    public void CameraMobilised()
    {
        Player1 = gameObject.GetComponent<LevelManager>().LvlStartPlayer1;
        Player2 = gameObject.GetComponent<LevelManager>().LvlStartPlayer2;
        cameraMobilised = true;
    }
}
