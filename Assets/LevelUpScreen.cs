using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{
    private int Health1;
    private int Health2;
    private int Armour1;
    private int Armour2;
    private int Speed1;
    private int Speed2;
    public Text Player1PointCounter;
    public Text Player2PointCounter;
    private int P1PointCount;
    private int P2PointCount;
    public Sprite HealingAbilityImg;
    public Sprite FireballImg;
    public Sprite VineImg;
    public GameObject Player1AbilityImg;
    public GameObject Player2AbilityImg;
    public Text Player1AbilityName;
    public Text Player2AbilityName;
    public GameObject HUD;

    void Start()
    {
        P1PointCount = 5;
        Player1PointCounter.text = P1PointCount.ToString();
        P2PointCount = 5;
        Player2PointCounter.text = P2PointCount.ToString();
    }

    public void LevelUpScreenSetup(char Player1, char Player2) //Sets the image and name of ability in Level up screen to match player classes
    {
        switch (Player1)
        {
            case 'f':
                Player1AbilityImg.GetComponent<Image>().sprite = HealingAbilityImg;
                Player1AbilityName.text = "Healing";
                break;
            case 'w':
                Player1AbilityImg.GetComponent<Image>().sprite = FireballImg;
                Player1AbilityName.text = "Fireball";
                break;
            case 'r':
                Player1AbilityImg.GetComponent<Image>().sprite = VineImg;
                Player1AbilityName.text = "Swinging";
                break;
        }

        switch (Player2)
        {
            case 'f':
                Player2AbilityImg.GetComponent<Image>().sprite = HealingAbilityImg;
                Player2AbilityName.text = "Healing";
                break;
            case 'w':
                Player2AbilityImg.GetComponent<Image>().sprite = FireballImg;
                Player2AbilityName.text = "Fireball";
                break;
            case 'r':
                Player2AbilityImg.GetComponent<Image>().sprite = VineImg;
                Player2AbilityName.text = "Swinging";
                break;
        }
    }

    //Behaviour for level up screen

    void UpdateAttribute(Text Counter, int count, Text PlayerPointCounter, bool Increase)
    {
        if (Increase)
        {
            if (PlayerPointCounter == Player1PointCounter)
            {
                if (P1PointCount <= 0)
                {
                    Debug.Log("Player 1, no");
                    return;
                }
                P1PointCount -= 1;
                PlayerPointCounter.text = P1PointCount.ToString();
            }
            else
            {
                if (P2PointCount <= 0)
                {
                    Debug.Log("Player 2, no");
                    return;
                }
                P2PointCount -= 1;
                PlayerPointCounter.text = P2PointCount.ToString();
            }
        }
        else
        {
            if (PlayerPointCounter == Player1PointCounter)
            {
                P1PointCount += 1;
                PlayerPointCounter.text = P1PointCount.ToString();
            }
            else
            {
                P2PointCount += 1;
                PlayerPointCounter.text = P2PointCount.ToString();
            }
        }
        Counter.text = count.ToString();
    }

    //Activated by continue button, passes attributes to level manager, which passes them to the appropriate players
    public void PassAttributes()
    {
        HUD.SetActive(true);
        gameObject.transform.parent.gameObject.GetComponent<LevelManager>().ContinueNextLevel(Health1, Health2, Speed1, Speed2, Armour1, Armour2);
    }

    public Text Health1Counter;

    public void Health1Increase()
    {
        Health1 += 1;
        UpdateAttribute(Health1Counter, Health1, Player1PointCounter, true);
    }

    public void Health1Decrease()
    {
        Health1 -= 1;
        UpdateAttribute(Health1Counter, Health1, Player1PointCounter, false);
    }

    public Text Health2Counter;

    public void Health2Increase()
    {
        Health2 += 1;
        UpdateAttribute(Health2Counter, Health2, Player2PointCounter, true);
    }

    public void Health2Decrease()
    {
        Health2 -= 1;
        UpdateAttribute(Health2Counter, Health2, Player2PointCounter, false);
    }

    public Text Speed1Counter;

    public void Speed1Increase()
    {
        Speed1 += 1;
        UpdateAttribute(Speed1Counter, Speed1, Player1PointCounter, true);
    }

    public void Speed1Decrease()
    {
        Speed1 -= 1;
        UpdateAttribute(Speed1Counter, Speed1, Player1PointCounter, false);
    }

    public Text Speed2Counter;

    public void Speed2Increase()
    {
        Speed2 += 1;
        UpdateAttribute(Speed2Counter, Speed2, Player2PointCounter, true);
    }

    public void Speed2Decrease()
    {
        Speed2 -= 1;
        UpdateAttribute(Speed2Counter, Speed2, Player2PointCounter, false);
    }

    public Text Armour1Counter;

    public void Armour1Increase()
    {
        Armour1 += 1;
        UpdateAttribute(Armour1Counter, Armour1, Player1PointCounter, true);
    }

    public void Armour1Decrease()
    {
        Armour1 -= 1;
        UpdateAttribute(Armour1Counter, Armour1, Player1PointCounter, false);
    }

    public Text Armour2Counter;

    public void Armour2Increase()
    {
        Armour2 += 1;
        UpdateAttribute(Armour2Counter, Armour2, Player2PointCounter, true);
    }

    public void Armour2Decrease()
    {
        Armour2 -= 1;
        UpdateAttribute(Armour2Counter, Armour2, Player2PointCounter, false);
    }
}
