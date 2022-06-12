using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy1_1;
    public GameObject Enemy1_2;
    public GameObject Enemy1_3;
    public GameObject Enemy1_4;
    public GameObject Enemy1_5;
    public GameObject Enemy1_6;
    public GameObject Enemy1_7;
    public GameObject Enemy1_8;
    public GameObject Enemy1_9;


    void Start()
    {
        
    }

    public void EnemyPlace()
    {
        Enemy1.SetActive(true);
        Enemy1_1.SetActive(true);
        Enemy1_2.SetActive(true);
        Enemy1_3.SetActive(true);
        Enemy1_4.SetActive(true);
        Enemy1_5.SetActive(true);
        Enemy1_6.SetActive(true);
        Enemy1_7.SetActive(true);
        Enemy1_8.SetActive(true);
        Enemy1_9.SetActive(true);

    }
}
