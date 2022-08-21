using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{

    
    [SerializeField] private int startingBalance = 150;
    [SerializeField] private int currentBalance;
    [SerializeField] private TMP_Text goldText;

    
    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
    }

    private void Update()
    {
        
    }

    public void Deposit(int amount)
    {
        
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
                
    }

    public void WithDraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if (currentBalance < 0)
        {
            //lose the game
            ReloadScene();
            
        }
        UpdateDisplay();
        
    }

    void UpdateDisplay()
    {

        goldText.text = $"Gold: {currentBalance}";
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
