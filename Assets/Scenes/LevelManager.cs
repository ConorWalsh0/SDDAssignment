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

        switch (player1CharacterSelect)
        {
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

        GameObject.Find("EnemyManager").GetComponent<Enemy>().Player1 = LvlStartPlayer1;
        GameObject.Find("EnemyManager").GetComponent<Enemy>().Player2 = LvlStartPlayer2;
        GameObject.Find("EnemyManager").GetComponent<EnemySpawn>().EnemyPlace();

        if (player1CharacterSelect == 'f' || player2CharacterSelect == 'f')
        {
            GameObject.Find("FighterClass").GetComponent<Ability1_1>().Ability1_1Setup();
        }
    }

    public void ContinueNextLevel()
    {
        //RespawnPoint.GetComponent<Respawn>().PlayerRespawn(player);
        gameObject.transform.Find("Menu_LevelUp1").gameObject.SetActive(false);
    }
}
