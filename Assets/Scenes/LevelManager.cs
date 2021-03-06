using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private char player1CharacterSelect;
    private char player2CharacterSelect;
    public GameObject LvlStartPlayer1;
    public GameObject LvlStartPlayer2;
    private GameObject CharacterCreation;
    private GameObject RespawnPoint;
    private GameObject EnemyManager;

    void Start()
    {
        CharacterCreation = GameObject.Find("CharacterCreation");
        RespawnPoint = GameObject.Find("RespawnPoint");
    }

    void Update()
    {
        
    }

    public void LevelStart()
    {
        player1CharacterSelect = CharacterCreation.GetComponent<CharacterCreation>().player1CharacterSelect;
        player2CharacterSelect = CharacterCreation.GetComponent<CharacterCreation>().player2CharacterSelect;

        switch (player1CharacterSelect) //Creates a reference for the player's chosen class, enables the correct player's stats/movement scripts
        {                               //then deletes the other player's stats/movement scripts, so that player can only control one character
            case 'f':
                LvlStartPlayer1 = GameObject.Find("FighterClass");
                LvlStartPlayer1.GetComponent<Player1Stats>().enabled = true;
                LvlStartPlayer1.GetComponent<Player1Movement>().enabled = true;
                LvlStartPlayer1.GetComponent<Player1Stats>().FighterSelected();
                break;
            case 'w':
                LvlStartPlayer1 = GameObject.Find("WizardClass");
                LvlStartPlayer1.GetComponent<Player1Stats>().enabled = true;
                LvlStartPlayer1.GetComponent<Player1Movement>().enabled = true;
                LvlStartPlayer1.GetComponent<Player1Stats>().WizardSelected();
                break;
            case 'r':
                LvlStartPlayer1 = GameObject.Find("RogueClass");
                LvlStartPlayer1.GetComponent<Player1Stats>().enabled = true;
                LvlStartPlayer1.GetComponent<Player1Movement>().enabled = true;
                LvlStartPlayer1.GetComponent<Player1Stats>().RogueSelected();
                break;
        }
        Destroy(LvlStartPlayer1.GetComponent<Player2Stats>());
        Destroy(LvlStartPlayer1.GetComponent<Player2Movement>());

        switch (player2CharacterSelect)
        {
            case 'f':
                LvlStartPlayer2 = GameObject.Find("FighterClass");
                LvlStartPlayer2.GetComponent<Player2Stats>().enabled = true;
                LvlStartPlayer2.GetComponent<Player2Movement>().enabled = true;
                LvlStartPlayer2.GetComponent<Player2Stats>().FighterSelected();
                break;
            case 'w':
                LvlStartPlayer2 = GameObject.Find("WizardClass");
                LvlStartPlayer2.GetComponent<Player2Stats>().enabled = true;
                LvlStartPlayer2.GetComponent<Player2Movement>().enabled = true;
                LvlStartPlayer2.GetComponent<Player2Stats>().WizardSelected();
                break;
            case 'r':
                LvlStartPlayer2 = GameObject.Find("RogueClass");
                LvlStartPlayer2.GetComponent<Player2Stats>().enabled = true;
                LvlStartPlayer2.GetComponent<Player2Movement>().enabled = true;
                LvlStartPlayer2.GetComponent<Player2Stats>().RogueSelected();
                break;
        }
        Destroy(LvlStartPlayer2.GetComponent<Player1Stats>());
        Destroy(LvlStartPlayer2.GetComponent<Player1Movement>());

        EnemyManager = GameObject.Find("EnemyManager"); //Assigns player object references and calls several methods
        EnemyManager.GetComponent<Enemy>().Player1 = LvlStartPlayer1;
        EnemyManager.GetComponent<Enemy>().Player2 = LvlStartPlayer2;
        EnemyManager.GetComponent<EnemySpawn>().EnemyPlace();
        EnemyManager.GetComponent<Enemy>().EnemyPlayerClassSetup();
        GameObject.Find("RespawnPoint").GetComponent<Respawn>().RespawnSetup();
        gameObject.transform.GetChild(0).gameObject.GetComponent<LevelUpScreen>().LevelUpScreenSetup(player1CharacterSelect, player2CharacterSelect); //Finds Menu_LevelUp1

        if (player1CharacterSelect == 'f' || player2CharacterSelect == 'f') //Tells the ability scripts of the players' chosen classes to perform setup
        {
            GameObject.Find("FighterClass").GetComponent<Ability0_1>().Ability0_1Setup();
            GameObject.Find("FighterClass").GetComponent<Ability1_1>().Ability1_1Setup();
        }
        if (player1CharacterSelect == 'w' || player2CharacterSelect == 'w')
        {
            GameObject.Find("WizardClass").GetComponent<Ability0_2>().Ability0_2Setup();
            GameObject.Find("WizardClass").GetComponent<Ability1_2>().Ability1_2Setup();
        }
        if (player1CharacterSelect == 'r' || player2CharacterSelect == 'r')
        {
            GameObject.Find("RogueClass").GetComponent<Ability0_3>().Ability0_3Setup();
            GameObject.Find("RogueClass").GetComponent<Ability1_3>().Ability1_3Setup();
        }
    }

    public void ContinueNextLevel(int Health1, int Health2, int Speed1, int Speed2, int Armour1, int Armour2)
    {
        gameObject.transform.Find("Menu_LevelUp1").gameObject.SetActive(false);
        Destroy(GameObject.Find("EnemyBarrier"));
        LvlStartPlayer1.GetComponent<Player1Stats>().Player1NextLevelStatUpdate(Health1, Speed1, Armour1);
        LvlStartPlayer2.GetComponent<Player2Stats>().Player2NextLevelStatUpdate(Health2, Speed2, Armour2);
    }

    public void NextPlayer1AbilityUnlocked() //Finds player 1's class and enables their next ability
    {
        if (player1CharacterSelect == 'f')
        {
            LvlStartPlayer1.GetComponent<Ability1_1>().Ability1_1Selected();
        }
        else if (player1CharacterSelect == 'w')
        {
            LvlStartPlayer1.GetComponent<Ability1_2>().Ability1_2Selected();
        }
        else if (player1CharacterSelect == 'r')
        {
            LvlStartPlayer1.GetComponent<Ability1_3>().Ability1_3Selected();
        }
    }

    public void NextPlayer2AbilityUnlocked()
    {
        if (player2CharacterSelect == 'f')
        {
            LvlStartPlayer2.GetComponent<Ability1_1>().Ability1_1Selected();
        }
        else if (player2CharacterSelect == 'w')
        {
            LvlStartPlayer2.GetComponent<Ability1_2>().Ability1_2Selected();
        }
        else if (player2CharacterSelect == 'r')
        {
            LvlStartPlayer2.GetComponent<Ability1_3>().Ability1_3Selected();
        }
    }
}
