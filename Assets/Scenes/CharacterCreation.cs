using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    public GameObject FighterClass;
    public GameObject WizardClass;
    public GameObject RogueClass;
    public Button Fighter1Select;
    public Button Wizard1Select;
    public Button Rogue1Select;
    public Button Fighter2Select;
    public Button Wizard2Select;
    public Button Rogue2Select;
    public char player1CharacterSelect;
    public char player2CharacterSelect;

    //Creates toggle behaviour for character creation screen UI, makes selected character active and deactivates deselected characters
    public void FighterSelectPlayer1()
    {
        Fighter2Select.interactable = !Fighter2Select.interactable;
        FighterClass.SetActive(true);

        //'\0' is default value of char variable
        //Default value occurs if this is player's first choice
        //further choices use switch statement to trigger behaviour depending on player's previous choice
        switch (player1CharacterSelect)
        {
            case '\0':
                player1CharacterSelect = 'f';
                return;
            case 'w':
                WizardClass.SetActive(false);
                Wizard2Select.interactable = !Wizard2Select.interactable;
                break;
            case 'r':
                RogueClass.SetActive(false);
                Rogue2Select.interactable = !Rogue2Select.interactable;
                break;
        }

        player1CharacterSelect = 'f';
    }

    public void WizardSelectPlayer1()
    {
        Wizard2Select.interactable = !Wizard2Select.interactable;
        WizardClass.SetActive(true);

        switch (player1CharacterSelect)
        {
            case '\0':
                player1CharacterSelect = 'w';
                return;
            case 'f':
                FighterClass.SetActive(false);
                Fighter2Select.interactable = !Fighter2Select.interactable;
                break;
            case 'r':
                RogueClass.SetActive(false);
                Rogue2Select.interactable = !Rogue2Select.interactable;
                break;
        }

        player1CharacterSelect = 'w';
    }

    public void RogueSelectPlayer1()
    {
        Rogue2Select.interactable = !Rogue2Select.interactable;
        RogueClass.SetActive(true);

        switch (player1CharacterSelect)
        {
            case '\0':
                player1CharacterSelect = 'r';
                return;
            case 'w':
                WizardClass.SetActive(false);
                Wizard2Select.interactable = !Wizard2Select.interactable;
                break;
            case 'f':
                FighterClass.SetActive(false);
                Fighter2Select.interactable = !Fighter2Select.interactable;
                break;
        }

        player1CharacterSelect = 'r';
    }

    public void FighterSelectPlayer2()
    {
        Fighter1Select.interactable = !Fighter1Select.interactable;
        FighterClass.SetActive(true);

        switch (player2CharacterSelect)
        {
            case '\0':
                player2CharacterSelect = 'f';
                return;
            case 'w':
                WizardClass.SetActive(false);
                Wizard1Select.interactable = !Wizard1Select.interactable;
                break;
            case 'r':
                RogueClass.SetActive(false);
                Rogue1Select.interactable = !Rogue1Select.interactable;
                break;
        }

        player2CharacterSelect = 'f';
    }

    public void WizardSelectPlayer2()
    {
        Wizard1Select.interactable = !Wizard1Select.interactable;
        WizardClass.SetActive(true);

        switch (player2CharacterSelect)
        {
            case '\0':
                player2CharacterSelect = 'w';
                return;
            case 'f':
                FighterClass.SetActive(false);
                Fighter1Select.interactable = !Fighter1Select.interactable;
                break;
            case 'r':
                RogueClass.SetActive(false);
                Rogue1Select.interactable = !Rogue1Select.interactable;
                break;
        }

        player2CharacterSelect = 'w';
    }

    public void RogueSelectPlayer2()
    {
        Rogue1Select.interactable = !Rogue1Select.interactable;
        RogueClass.SetActive(true);

        switch (player2CharacterSelect)
        {
            case '\0':
                player2CharacterSelect = 'r';
                return;
            case 'w':
                WizardClass.SetActive(false);
                Wizard1Select.interactable = !Wizard1Select.interactable;
                break;
            case 'f':
                FighterClass.SetActive(false);
                Fighter1Select.interactable = !Fighter1Select.interactable;
                break;
        }

        player2CharacterSelect = 'r';
    }
}
