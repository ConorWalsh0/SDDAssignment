using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy1_1;

    void Start()
    {
        
    }

    public void EnemyPlace()
    {
        Enemy1.SetActive(true);
        Enemy1_1.SetActive(true);
    }
}
