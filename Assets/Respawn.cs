using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject Player1;

    void Start()
    {
        Player1 = GameObject.Find("Player1");
    }

    void Update()
    {
        
    }

    public void PlayerRespawn()
    {
        Player1.transform.position = gameObject.transform.position;
        Player1.SetActive(true);
    }
}
