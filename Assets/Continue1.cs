using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue1 : MonoBehaviour
{
    private GameObject RespawnPoint;

    void Start()
    {
        RespawnPoint = GameObject.Find("RespawnPoint");
    }
    
    void Update()
    {
        
    }

    public void Continue1NextLevel()
    {
        RespawnPoint.GetComponent<Respawn>().PlayerRespawn();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
