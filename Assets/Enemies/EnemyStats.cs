using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    private GameObject Enemy1;
    private int Enemy1Damage;

    void Start()
    {
        Enemy1 = GameObject.Find("Enemy1");
        Enemy1Damage = 30;
    }

    void Update()
    {
        
    }

    public int RetrieveEnemyDamage(GameObject enemyGameObject)
    {
        if (enemyGameObject == null)
        {
            return 0;
        }
        else if (enemyGameObject == Enemy1)
        {
            return Enemy1Damage;
        }
        else
        {
            return 0;
        }
    }
}
