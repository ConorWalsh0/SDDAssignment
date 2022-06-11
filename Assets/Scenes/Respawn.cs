using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject Player1;
    private GameObject Player2;
    private GameObject MainCamera;
    private bool SetupFlag;

    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    public void RespawnSetup()
    {
        Player1 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer1;
        Player2 = MainCamera.GetComponent<LevelManager>().LvlStartPlayer2;
        SetupFlag = true;
    }

    public void PlayerRespawn(GameObject Player)
    {
        Player.transform.position = gameObject.transform.position;
        Player.SetActive(true);
    }

    void Update()
    {
        if (SetupFlag != true)
        {
            return;
        }

        if (Player1 != null && Player2 != null)
        {
            gameObject.transform.position = MainCamera.GetComponent<Players>().PlayersMidpoint(Player1, Player2) + new Vector2(0f, 5f);
        }

        if (Player2 == null)
        {
            gameObject.transform.position = Player1.transform.position + new Vector3(0f, 5f, gameObject.transform.position.z);
        }
        
        if (Player1 == null)
        {
            gameObject.transform.position = Player2.transform.position + new Vector3(0f, 5f, gameObject.transform.position.z);
        }
    }
}
