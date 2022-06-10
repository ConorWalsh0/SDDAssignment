using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public GameObject Enemy1Hitbox;
    private int enemy1Damage;

    void Start()
    {
        enemy1Damage = 30;
    }

    void Update()
    {
        
    }

    public int RetrieveEnemyDamage(GameObject enemyGameObject)
    {
        if (enemyGameObject == null)
        {
            Debug.Log("enemygameobject is null, check EnemyStats.cs");
            return 0;
        }
        else if (enemyGameObject.tag == "Enemy1Hitbox")
        {
            return enemy1Damage;
        }
        else
        {
            return 0;
        }
    }
}
