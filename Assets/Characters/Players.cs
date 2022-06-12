using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public Vector3 playersMidpoint;
    private Vector3 Player1Pos;
    private Vector3 Player2Pos;
    public int playerHealth;
    public int maxPlayerHealth;
    public int playerDamage;
    public int playerArmour;
    public float playerSpeedModifier;
    public float knockback;
    public GameObject RespawnPoint;
    public GameObject Menu_LevelUp1;
    public GameObject Credits;
    private int enemyDamage;
    public GameObject EnemyManager;

    public Vector2 PlayersMidpoint(GameObject P1, GameObject P2)
    {
        Player1Pos = P1.transform.position;
        Player2Pos = P2.transform.position;
        playersMidpoint = new Vector2((Player1Pos.x + Player2Pos.x) / 2, (Player1Pos.y + Player2Pos.y) / 2);
        return playersMidpoint;
    }

    public void Knockback(Collision2D collision, GameObject playerGameObject, Rigidbody2D rb2D, float knockback, float playerSpeedModifier)
    {
        Vector2 enemyPos = collision.transform.position;
        Vector2 origin = playerGameObject.transform.position;
        Vector2 direction = origin - enemyPos;
        direction.Normalize();
        direction.y += 1f;
        rb2D.AddForce(new Vector2(knockback * direction.x * playerSpeedModifier, knockback * direction.y * playerSpeedModifier), ForceMode2D.Impulse);
    }

    public int PlayerDamageTaken(Collision2D collision, GameObject playerGameObject, int playerArmour, int playerHealth, int maxPlayerHealth) //enemydamage currently zero, but is instantly killing player
    {
        enemyDamage = EnemyManager.GetComponent<EnemyStats>().RetrieveEnemyDamage(collision.collider.gameObject); //finds the gameObject associated with the player collision
        if (enemyDamage - playerArmour < 0)                                                                       //and finds the gameObject's damage if an enemy
        {
            playerHealth -= 1;
        }
        else
        {
            playerHealth -= (enemyDamage - playerArmour);
        }

        if (playerHealth <= 0)
        {
            playerGameObject.SetActive(false);
            playerHealth = Respawn(playerHealth, maxPlayerHealth, playerGameObject);
        }

        return playerHealth;
    }

    public int Respawn(int playerHealth, int maxPlayerHealth, GameObject Player)
    {
        RespawnPoint.GetComponent<Respawn>().PlayerRespawn(Player);
        playerHealth = maxPlayerHealth;
        return playerHealth;
    }

    public void LevelFinish()
    {
        Debug.Log("yay");
        Menu_LevelUp1.SetActive(true);
    }

    public void GameFinish()
    {
        Credits.SetActive(true);
        Debug.Log("Congratulations");
    }
}
