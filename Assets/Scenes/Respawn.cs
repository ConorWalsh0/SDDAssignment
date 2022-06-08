using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void PlayerRespawn(GameObject Player)
    {
        Player.transform.position = gameObject.transform.position;
        Player.SetActive(true);
    }
}
