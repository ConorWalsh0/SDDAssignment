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
    public char Player1CharacterSelect;
    public char Player2CharacterSelect;

    //Creates toggle behaviour for character creation screen UI, makes selected character active and deactivates deselected characters
    public void FighterSelectPlayer1()
    {
        Fighter2Select.interactable = !Fighter2Select.interactable;
        FighterClass.SetActive(true);

        //'\0' is default value of char variable
        switch (Player1CharacterSelect)
        {
            case '\0':
                Player1CharacterSelect = 'f';
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

        Player1CharacterSelect = 'f';
    }

    public void WizardSelectPlayer1()
    {
        Wizard2Select.interactable = !Wizard2Select.interactable;
        WizardClass.SetActive(true);

        switch (Player1CharacterSelect)
        {
            case '\0':
                Player1CharacterSelect = 'w';
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

        Player1CharacterSelect = 'w';
    }

    public void RogueSelectPlayer1()
    {
        Rogue2Select.interactable = !Rogue2Select.interactable;
        RogueClass.SetActive(true);

        switch (Player1CharacterSelect)
        {
            case '\0':
                Player1CharacterSelect = 'r';
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

        Player1CharacterSelect = 'r';
    }

    public void FighterSelectPlayer2()
    {
        Fighter1Select.interactable = !Fighter1Select.interactable;
        FighterClass.SetActive(true);

        switch (Player2CharacterSelect)
        {
            case '\0':
                Player2CharacterSelect = 'f';
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

        Player2CharacterSelect = 'f';
    }

    public void WizardSelectPlayer2()
    {
        Wizard1Select.interactable = !Wizard1Select.interactable;
        WizardClass.SetActive(true);

        switch (Player2CharacterSelect)
        {
            case '\0':
                Player2CharacterSelect = 'w';
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

        Player2CharacterSelect = 'w';
    }

    public void RogueSelectPlayer2()
    {
        Rogue1Select.interactable = !Rogue1Select.interactable;
        RogueClass.SetActive(true);

        switch (Player2CharacterSelect)
        {
            case '\0':
                Player2CharacterSelect = 'r';
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

        Player2CharacterSelect = 'r';
    }
}
