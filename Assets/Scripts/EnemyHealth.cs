using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int maxHitpoints = 5;
    [Tooltip("Adds amount to max hitpoints to when enemy dies.")]
    [SerializeField] private int difficultyLevel = 1;

    
    private int currentHitpoint = 0;
    private Enemy enemy;

    private void Awake()
    {
        
        enemy = GetComponent<Enemy>();
        
    }

    void OnEnable()
    {
        currentHitpoint = maxHitpoints;
    }

    private void OnParticleCollision(GameObject other)
    {

        ProcessHit();
    }


    void ProcessHit()
    {
        
        currentHitpoint--;
        if (currentHitpoint <= 0)
        {
            enemy.RewardGold();
            maxHitpoints += difficultyLevel;
            gameObject.SetActive(false);
        }


    }
    
}
