using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Reflection;
using TMPro.Examples;
public class game_manager : MonoBehaviour

    
{
    public int health, coins;
    public Playermovement playerMovement;
    public TextMeshProUGUI hp_value, coin_value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = playerMovement.hp;
        coins = playerMovement.coinCounter;
        hp_value.text = health.ToString();
        coin_value.text = coins.ToString();
    }
}
