using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(0.1f,30f)] private float timeBetweenSpawns = 2f;
    [SerializeField] [Range(0,50f)] private int poolSize = 5;

    private GameObject[] pool;


    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i =0;i<pool.Length;i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);

        }
        
    }
 
    private IEnumerator EnemySpawner()
    {

        while (true)
        {
            EnableObjectInPool();     
            yield return new WaitForSeconds(timeBetweenSpawns);
        }  
        
        
    }

    void EnableObjectInPool()
    {

        for(int i =0;i<pool.Length;i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
        
    }
    
}
