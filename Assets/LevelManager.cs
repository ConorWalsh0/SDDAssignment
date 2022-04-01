using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject Enemy1;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void LevelStart()
    {
        Enemy1.SetActive(true);
    }
}
