using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Stats : Players
{
    //general stats
    private float invincibilityTime = 0;

    //Healing info
    public int particleHealth;
    private int partialHeal;

    //external objects
    private int enemy1Damage;
    private Rigidbody2D rb2D;
    private char Player1Class;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Player1Class = GameObject.Find("CharacterCreation").GetComponent<CharacterCreation>().player1CharacterSelect;

        this.maxPlayerHealth = 100;
        this.playerHealth = maxPlayerHealth;
        this.particleHealth = 5;
        this.playerDamage = 30;
        this.playerSpeedModifier = 1f;
        this.playerArmour = 0;
        this.knockback = 50f;
    }

    void Update()
    {
        if (invincibilityTime > 0f)
        {
            invincibilityTime -= Time.deltaTime;
        }
    }

    public void FighterSelected()
    {
        Debug.Log("FighterSelected");
    }

    public void WizardSelected()
    {
        Debug.Log("WizardSelected");
    }

    public void RogueSelected()
    {
        Debug.Log("RogueSelected");
    }

}
