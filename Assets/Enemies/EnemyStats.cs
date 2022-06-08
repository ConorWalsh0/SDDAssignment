using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    private GameObject Enemy1; //maybe get gameObjects from Enemy parent class?

    void Start()
    {
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
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
